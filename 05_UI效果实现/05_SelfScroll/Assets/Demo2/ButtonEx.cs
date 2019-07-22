#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build.Reporting;
#endif
using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
    /// <summary>
    /// 扩展 ButtonEx, 支持更多的事件设计
    /// </summary>
    [AddComponentMenu("UGUI/ButtonEx", 1), RequireComponent(typeof(RectTransform))]
    public class ButtonEx : UnityEngine.UI.Selectable, IPointerClickHandler, ISubmitHandler, IPointerDownHandler,
        IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        
        /// <summary>
        /// 长按等待时间
        /// </summary>
        public float onLongWaitTime = 1.0f;


        /// <summary>
        /// 不断的产生长按事件
        /// </summary>
        public bool onLongContinue = false;

        [Serializable]
        public class ButtonClickedEvent : UnityEvent { }
        
        [FormerlySerializedAs("onClick")]
        [SerializeField]
        private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();
        
        [FormerlySerializedAs("onLongClick")]
        [SerializeField]
        private ButtonClickedEvent m_OnLongClick = new ButtonClickedEvent();
        
        [FormerlySerializedAs("onDown")]
        [SerializeField]
        private ButtonClickedEvent m_OnDown = new ButtonClickedEvent();
        
        [FormerlySerializedAs("onUp")]
        [SerializeField]
        private ButtonClickedEvent m_OnUp = new ButtonClickedEvent();
        
        [FormerlySerializedAs("onEnter")]
        [SerializeField]
        private ButtonClickedEvent m_OnEnter = new ButtonClickedEvent();
        
        [FormerlySerializedAs("onExit")]
        [SerializeField]
        private ButtonClickedEvent m_OnExit = new ButtonClickedEvent();
        
        protected ButtonEx() : base()
        { 
        }
        
        /// <summary>
        /// 文本值
        /// </summary>
        public string text
        {
            get
            {
                Text v = getText();
                if (v != null)
                    return v.text;
                return null;
            }

            set
            {
                Text v = getText();
                if (v != null)
                    v.text = value;
            }
        }


        private bool isPointerDown = false;
        private bool isPointerInside = false;
        
        /// <summary>
        /// 是否被按下
        /// </summary>
        public bool isDown
        {
            get => isPointerDown;
            
        }
        
        /// <summary>
        /// 是否进入
        /// </summary>
        public bool isEnter
        {
            get => isPointerInside;
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        public ButtonClickedEvent onClick
        {
            get => m_OnClick;
            set => m_OnClick = value;
        }
        
        /// <summary>
        /// 长按事件
        /// </summary>
        public ButtonClickedEvent onLongClick
        {
            get => m_OnLongClick;
            set => m_OnLongClick = value;
        }

        /// <summary>
        /// 按下事件
        /// </summary>
        public ButtonClickedEvent onDown
        {
            get => m_OnDown;
            set => m_OnDown = value;
        }
        
        /// <summary>
        /// 松开事件
        /// </summary>
        public ButtonClickedEvent onUp
        {
            get => m_OnUp;
            set => m_OnUp = value;
        }
        
        /// <summary>
        /// 进入事件
        /// </summary>
        public ButtonClickedEvent onEnter
        {
            get => m_OnEnter;
            set => m_OnEnter = value;
        }

        /// <summary>
        /// 离开事件
        /// </summary>
        public ButtonClickedEvent onExit
        {
            get => m_OnExit;
            set => m_OnExit = value;
        }


        private System.Reflection.BindingFlags getRBFlag()
        {
            return System.Reflection.BindingFlags.Static |
                   System.Reflection.BindingFlags.NonPublic |
                   System.Reflection.BindingFlags.GetProperty |
                   System.Reflection.BindingFlags.Instance |
                   System.Reflection.BindingFlags.GetField |
                   System.Reflection.BindingFlags.ExactBinding;

        }

        private void Press()
        {
            if (!IsActive() || !IsInteractable()|| isLong)
                return;
            m_OnClick.Invoke();
        }


        private void Down()
        {
            if (!IsActive() || !IsInteractable())
                return;
            m_OnDown.Invoke();
            Debug.Log("<color=aqua>走这里</color>");
            StartCoroutine(grow());
        }

    
        private void Up()
        {
            if (!IsActive() || !IsInteractable() || !isDown)
                return;
            if (isLong)
            {
                isLong = false;
                m_OnUp.Invoke();
            }
            else
            {
                m_OnUp.Invoke();
                Press();
            }

          
        }

        private void Enter()
        {
            if (!IsActive())
                return;
            m_OnEnter.Invoke();
        }


        private void Exit()
        {
            if (!IsActive() || !isEnter)
                return;
            m_OnExit.Invoke();
        }

        private bool isLong = false;
        private void LongClick()
        {
            if (!IsActive() || !isDown)
                return;
            isLong = true;
            m_OnLongClick.Invoke();
        }


        private float downTime = 0f;
        private IEnumerator grow()
        {
            downTime = Time.time;
            while (isDown)
            {
                if (Time.time - downTime > onLongWaitTime)
                {
                    LongClick();
                    if (onLongContinue)
                        downTime = Time.time;
                    else
                        break;
                }
                else
                {
                    yield return null;
                }
            }

        }

        protected override void OnDisable()
        {
            isPointerDown = false;
            isPointerInside = false;
        }
        


        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
//            Press(); //这里屏蔽掉点击方法，防止长按后会多调用一次点击方法，现在将点击方法press() 放在Up()方法中调用
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            isPointerDown = true;
            Down();
            base.OnPointerDown(eventData);
        }
        
        public override void OnPointerUp(PointerEventData eventData) {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            Up ();
            isPointerDown = false;
            base.OnPointerUp (eventData);
        }


        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            isPointerInside = true;
            Enter();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            Exit();
            isPointerInside = false;
            base.OnPointerExit(eventData);
        }
        
        

        public void OnSubmit(BaseEventData eventData)
        {
            
            Debug.Log("<color=aqua> OnClick 走这里</color>");
            Press();
            if (!IsActive() || !IsInteractable())
                return;
            DoStateTransition(SelectionState.Pressed ,false);
            StartCoroutine(OnFinishSubmit());

        }

        private IEnumerator OnFinishSubmit()
        {
            var fadeTime = colors.fadeDuration;
            var elapsedTime = 0f;
            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }
            
            DoStateTransition(currentSelectionState,false);
        }

        private UnityEngine.UI.Text getText()
        {
            Transform f = transform.Find("Text");
            Text v = null;
            if (f != null)
                v = f.gameObject.GetComponent<Text>();

            if (v == null && transform.childCount > 0)
            {
                GameObject obj = transform.GetChild(0).gameObject;
                v = obj.GetComponent<Text>();
            }

            return v;
        }
        
        
        #if UNITY_EDITOR
        [MenuItem("GameObject/UI/ButtonEx")]
        static void CreateButtonFx(MenuCommand menuCmd)
        {
            //创建游戏对象
            float w = 160f;
            float h = 80f;

            GameObject btnRoot = UICommon.CreateUIElementRoot("ButtonEx", w, h);

            UICommon.CreateUIText("Text", "Button", btnRoot);
            
            //添加脚本
            btnRoot.AddComponent<CanvasRenderer>();
            Image img = btnRoot.AddComponent<Image>();
            img.color = Color.white;
            img.fillCenter = true;
            img.raycastTarget = true;
            if (img.sprite != null)
                img.type = Image.Type.Sliced;

            btnRoot.AddComponent<ButtonEx>();
            btnRoot.GetComponent<Selectable>().image = img;

            UICommon.PlaceUIElementRoot(btnRoot, menuCmd);
        }
#endif
        
    }
 
}

