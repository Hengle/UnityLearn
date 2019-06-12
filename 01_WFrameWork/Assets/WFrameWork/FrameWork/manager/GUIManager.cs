using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WFramework
{
    public enum UILayer
    {
        Bg,
        Common,
        Top,
    }

    public class GUIManager
    {
        private static GameObject _mPrivateUIRoot;

        public static GameObject UIRoot
        {
            get
            {
                if (_mPrivateUIRoot == null)
                {
                    _mPrivateUIRoot = Object.Instantiate(Resources.Load<GameObject>("UIRoot"));
                    _mPrivateUIRoot.name = "UIRootW";
                }

                return _mPrivateUIRoot;
            }
        }

        private static Dictionary<string, GameObject> _mPanelDict = new Dictionary<string, GameObject>();


        public static void SetResolution(float width, float height, float machWidthOrHeight)
        {
            var canvasScaler = UIRoot.GetComponent<CanvasScaler>();
            canvasScaler.referenceResolution = new Vector2(width, height);
            canvasScaler.matchWidthOrHeight = machWidthOrHeight;
        }

        public static void UnLoadPanel(string panelName)
        {
            if (_mPanelDict.ContainsKey(panelName))
            {
                Object.Destroy(_mPanelDict[panelName]);
            }
        }

        public static GameObject LoadPanel(string panelName, UILayer uiLayer)
        {
            var panelPrefab = Resources.Load<GameObject>(panelName);
            var panelObj = Object.Instantiate(panelPrefab);
            panelObj.name = panelName;

            _mPanelDict.Add(panelName, panelObj);
            switch (uiLayer)
            {
                case UILayer.Top:
                    panelObj.transform.SetParent(UIRoot.transform.Find("Top"));
                    break;
                case UILayer.Common:
                    panelObj.transform.SetParent(UIRoot.transform.Find("Common"));
                    break;
                case UILayer.Bg:
                    panelObj.transform.SetParent(UIRoot.transform.Find("Bg"));
                    break;
            }

            var panelRectTrans = panelObj.transform as RectTransform;
            if (!panelRectTrans)
            {
                throw new UnityException(" panelObj transform trans RectTransform failed!!!");
            }
            panelRectTrans.offsetMin = Vector2.zero;
            panelRectTrans.offsetMax = Vector2.zero;
            panelRectTrans.anchoredPosition3D = Vector3.zero;
            panelRectTrans.anchorMin = Vector2.zero;
            panelRectTrans.anchorMax = Vector2.one;
            panelRectTrans.localScale = Vector3.one;

            return panelObj;
        }
    }
}