using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;


namespace UIExtension
{
    public class EnchanceScrollView : MonoBehaviour
    {
        public ScrollRect Scroll;
        public GameObject Target;
        public GridLayoutGroup Grid;

        public int Num = 10;

        public void SetNum(int num)
        {
            Num = num;

            Init();
        }

        private void Start()
        {
            if (Target == null)
            {
                throw new Exception("还没有设置需要初始化的物品");
            }

            Target.SetActive(false);
            if (Grid == null)
            {
                throw new Exception("还没有设置好LayOut组件！！！");
            }
            
            Init();
        }

        public void Init()
        {
            Grid.enabled = true;
            //1.初始化物体
            if (Num != null && Num > 0)
            {
                Debug.Log("<color=aqua>需要展示的数量为：" + GetShowCount()+"</color>");
                for (int i = 0; i < (Num<GetShowCount()?Num:GetShowCount()); i++)
                {

                    var obj = Instantiate(Target);
                    obj.transform.SetParent(Grid.transform);
                    obj.SetActive(true);
                    obj.transform.name = "item_" + i;
                }
            }
            else
            {
                throw new Exception("初始化的数量还没有确定！！！");
            }
        }

        #region private

        //获取需要展示的数量
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
                float height = Scroll.gameObject.GetComponent<RectTransform>().sizeDelta.y ;
                float item_height = Grid.cellSize.y + Grid.spacing.y; 
                showCount = Mathf.CeilToInt(height / item_height);
            }
            else
            {
                throw new Exception("滑动列表滑动方向设置错误！！！");
            }
            return showCount;
        }
        
        
        #endregion
    }
    
    
}
