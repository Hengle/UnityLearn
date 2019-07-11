using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UIExtension
{
    
    public delegate void EScrollRefresh(int index, GameObject obj);
    public class EnchanceScrollView : MonoBehaviour
    {
        private EScrollRefresh refresh;
        public ScrollRect Scroll;
        public GameObject Target;
        public GridLayoutGroup Grid;

        public int Num;

        public float MoveSpeed;
        
        private bool _isInit = false;
        private Dictionary<GameObject, int> datasAndIndex = new Dictionary<GameObject, int>();
        private List<GameObject> needDispose = new List<GameObject>();
     

        private void Start()
        {
            if (Num == null || Num == 0) Num = 10;
            if (MoveSpeed == null || MoveSpeed == 0) MoveSpeed = 5;
            
            Grid.enabled = false;
            if (Target == null)
            {
                throw new Exception("还没有设置需要初始化的物品");
            }

            Target.SetActive(false);
            if (Grid == null)
            {
                throw new Exception("还没有设置好LayOut组件！！！");
            }

            StartCoroutine(Init());

            Scroll.onValueChanged.AddListener(OnListenMove);
        }


        private void OnDestroy()
        {
            if (refresh != null)
            {
                refresh = null;
            }
        }

        #region public
//===========================================================================================
        public void SetNum(int num)
        {
            Num = num;

            StartCoroutine(Init());
        }

        public void AddRefresh(EScrollRefresh func)
        {
            if (refresh != null)
            {
                refresh += func;
            }
            else
            {
                refresh = func;
            }
        }

        private Coroutine m_Coroutine;
        public void MoveToIndex(int index, float delay)
        {
            if(index<0||index>Num-1) 
                throw new Exception("需要定位的位置错误：" + index );

            index = Math.Min(index, Num - GetShowCount() + 2);
            index = Math.Max(0, index);

            var rect = Grid.GetComponent<RectTransform>();
            Vector2 pos = rect.anchoredPosition;

            Vector2 V2Pos;
            if (Scroll.horizontal)
            {
                V2Pos = new Vector2(-GetPos(index),rect.anchoredPosition.y);
            }
            else
            {
                V2Pos = new Vector2(rect.anchoredPosition.x, -GetPos(index));
            }

            m_Coroutine = StartCoroutine(TweenMoveToPos(pos, V2Pos, delay));
        }
        
        
//================================================================================================
        #region private

        private void SetItemRecord(int index, RectTransform go)
        {
            if (index > Num) return;
            datasAndIndex[go.gameObject] = index;

            //设置位置
            go.pivot = new Vector2(0, 1);
            if (Scroll.horizontal && !Scroll.vertical) //横向
            {
                go.anchoredPosition3D = new Vector3(GetPos(index), 0, 0);
            }
            else if (!Scroll.horizontal && Scroll.vertical) //纵向
            {
                go.anchoredPosition3D = new Vector3(0, GetPos(index), 0);
            }

            go.gameObject.name = "item" + index;
            refresh?.Invoke(index,go.gameObject);
        }

        //获取需要展示的数量
        
        private IEnumerator Init()
        {
            _isInit = true;
            //0.设置物体的框和高
            var _rect = Grid.GetComponent<RectTransform>();
            if (Scroll.horizontal)
            {
                _rect.sizeDelta = new Vector2((Grid.cellSize.x+Grid.spacing.x)*Num,_rect.sizeDelta.y);   
            }
            else
            {
                _rect.sizeDelta = new Vector2(_rect.sizeDelta.x,(Grid.cellSize.y+Grid.spacing.y)*Num);
            }
            _rect.localPosition = Vector3.zero;
            
            
            //1.初始化物体
            if (Num != null && Num > 0)
            {
                Debug.Log("<color=aqua>需要展示的数量为：" + GetShowCount() + "</color>");
                for (int i = 0; i < (Num < GetShowCount() ? Num : GetShowCount()); i++)
                {
                    GameObject obj;

                    if (needDispose.Count > 0)
                    {
                        obj = needDispose[0];
                    }
                    else
                    {
                        obj = Instantiate(Target);
                    }
                    obj.transform.SetParent(Grid.transform);
                    obj.SetActive(true);
                    var rect = obj.GetComponent<RectTransform>();
                    rect.sizeDelta = new Vector2(Grid.cellSize.x, Grid.cellSize.y);
                    SetItemRecord(i, obj.GetComponent<RectTransform>());
                }
            }
            else
            {
                throw new Exception("初始化的数量还没有确定！！！");
            }

            yield return new WaitForSeconds(0.1f);
            _isInit = false;
        }
        
        private int GetShowCount()
        {
            int showCount = 0;
            //1.首先判断是横向还是纵向：
            if (Scroll.horizontal && !Scroll.vertical) //横向
            {
                float width = Scroll.gameObject.GetComponent<RectTransform>().sizeDelta.x;
                float item_width = Grid.cellSize.x + Grid.spacing.x;
                showCount = Mathf.CeilToInt(width / item_width);
            }
            else if (!Scroll.horizontal && Scroll.vertical) //纵向
            {
                float height = Scroll.gameObject.GetComponent<RectTransform>().sizeDelta.y;
                float item_height = Grid.cellSize.y + Grid.spacing.y;
                showCount = Mathf.CeilToInt(height / item_height);
            }
            else
            {
                throw new Exception("滑动列表滑动方向设置错误！！！");
            }

            return showCount+1;
        }


        //拖动监听方法
        private void OnListenMove(Vector2 vector)
        {
            if (_isInit == true) return;
            
            if (Num < GetShowCount()) return; //展示的数量超过需要的数量，不可滑动
            int indexNow;
            if (Scroll.horizontal)
            {
                indexNow = GetIndex(Grid.GetComponent<RectTransform>().anchoredPosition3D.x); //返回当前的是第几个物体
            }
            else
            {
                indexNow = GetIndex(Grid.GetComponent<RectTransform>().anchoredPosition3D.y); //返回当前的是第几个物体
            }

            Debug.Log("<color=aqua> 当前的Index：" + indexNow + " </color>");

            foreach (var go in datasAndIndex.Keys)
            {
                if (datasAndIndex[go] >= indexNow && datasAndIndex[go] < indexNow + GetShowCount())
                {
                    //没有超出范围，
                    continue;
                }
                else
                {
                    //超出范围，收回到对象池内
                    needDispose.Add(go);
                }
            }

            foreach (var go in needDispose)
            {
                datasAndIndex.Remove(go);
                go.gameObject.SetActive(false);
            }

            for (int i = indexNow; i < indexNow + GetShowCount(); i++)
            {
                if (datasAndIndex.ContainsValue(i))
                {
                    continue;
                }
                else
                {
                    if (i < Num)
                    {
                        RectTransform item;
                        if (needDispose.Count > 0)
                        {
                            item = needDispose[0].GetComponent<RectTransform>();
                            needDispose.RemoveAt(0);
                        }
                        else
                        {
                            item = Instantiate(Target).GetComponent<RectTransform>();
                        }

                        item.transform.SetParent(Grid.transform);
                        item.gameObject.SetActive(true);
                        item.sizeDelta = new Vector2(Grid.cellSize.x, Grid.cellSize.y);
                        SetItemRecord(i, item);
                    }
                }
            }
        }


        //根据当前位置信息获取对应的Index
        private int GetIndex(float curps)
        {
            int index = 0;
            float size = 0;
            for (int i = 0; i < Num; i++)
            {
                if (Scroll.horizontal && !Scroll.vertical) //横向
                {
                    size -= (Grid.cellSize.x + Grid.spacing.x);
                    if (size < curps)
                    {
                        index = i;
                        break;
                    }
                }
                else if (!Scroll.horizontal && Scroll.vertical) //纵向
                {
                    size += Grid.cellSize.y + Grid.spacing.y;
                    
                    if (size > curps)
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        private float GetPos(int index)
        {
            float size = 0;
            for (int i = 0; i < index; i++)
            {
                if (Scroll.horizontal)
                    size += Grid.cellSize.x + Grid.spacing.x;
                else
                    size -= Grid.cellSize.y + Grid.spacing.y;
            }

            return size;
        }
        
        protected IEnumerator TweenMoveToPos(Vector2 pos, Vector2 v2Pos, float delay)
        {
            bool running = true;
            float passedTime = 0f;
            while (running)
            {
                yield return new WaitForEndOfFrame();
                passedTime += Time.deltaTime;
                Vector2 vCur;
                if (passedTime >= delay)
                {
                    vCur = v2Pos;
                    running = false;
                    StopCoroutine(m_Coroutine);
                    m_Coroutine = null;
                }
                else
                {
                    vCur = Vector2.Lerp(pos, v2Pos, passedTime / delay);
                }
                Grid.GetComponent<RectTransform>().anchoredPosition = vCur;
            }

        }

        #endregion
        
        #endregion
    }
}