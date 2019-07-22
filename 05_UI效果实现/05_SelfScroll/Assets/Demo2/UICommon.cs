using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityEngine.UI
{
    public class UICommon
    {
        /// <summary>
        /// 创建根结点UI对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="size">对象大小</param>
        public static GameObject CreateUIElementRoot(string name, Vector2 size) {
            GameObject go = new GameObject(name);
            RectTransform rect = go.AddComponent<RectTransform> ();
            rect.sizeDelta = size; 
            return go;
        } 
        
        /// <summary>
        /// 创建根结点UI对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="w">宽度</param>
        /// <param name="h">高度</param>
        public static GameObject CreateUIElementRoot(string name, float w, float h) {
            return CreateUIElementRoot (name, new Vector2 (w, h));
        }
        
        /// <summary>
        /// 创建UI Text 控件
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="text">文本内容</param>
        /// <param name="parent">父亲</param>
        public static GameObject CreateUIText(string name, string text, GameObject parent) {
            GameObject childText = UICommon.CreateUIObject(name, parent);
            Text v = childText.AddComponent<Text>();
            v.text = text;
            v.alignment = TextAnchor.MiddleCenter;
            RectTransform r = childText.GetComponent<RectTransform> ();
            r.anchorMin = Vector2.zero;
            r.anchorMax = Vector2.one;
            r.sizeDelta = Vector2.zero;
            v.color = Color.black;

            return childText;
        }
        
        /// <summary>
        /// 创建UI对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="parent">父级</param>
        public static GameObject CreateUIObject(string name, GameObject parent) {
            GameObject go = new GameObject(name);
            go.AddComponent<RectTransform>();
            SetParentAndAlign(go, parent);
            return go;
        }
        
        /// <summary>
        /// 设置父级对齐方式
        /// </summary>
        public static void SetParentAndAlign(GameObject child, GameObject parent) {
            if (parent == null)
                return;

            child.transform.SetParent(parent.transform, false);
        }

        /// <summary>
        /// 放置UI对象到UI层Canvas中
        /// </summary>
        public static void PlaceUIElementRoot(GameObject element, MenuCommand menuCommand) {
#if UNITY_EDITOR
            GameObject parent = menuCommand.context as GameObject;
            if (parent == null || parent.GetComponentInParent<Canvas>() == null) {
                Debug.LogError("UI需要设置在UIcanvas下");                
            }

            string uniqueName = GameObjectUtility.GetUniqueNameForSibling(parent.transform, element.name);
            element.name = uniqueName;
            Undo.RegisterCreatedObjectUndo(element, "Create " + element.name);
            Undo.SetTransformParent(element.transform, parent.transform, "Parent " + element.name);
            GameObjectUtility.SetParentAndAlign(element, parent);
            if (parent != menuCommand.context) // not a context click, so center in sceneview
                        Debug.LogError("设置UI父物体出错");
            Selection.activeGameObject = element;
#endif
        }


    }
    
    
}