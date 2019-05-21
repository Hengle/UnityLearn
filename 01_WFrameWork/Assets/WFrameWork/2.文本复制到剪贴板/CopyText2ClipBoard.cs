using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace WFrameWork
{
    public class CopyText2ClipBoard
    {
#if UNITY_EDITOR
        [MenuItem("WFrameWork/02.复制文本到剪贴板")]
#endif
        private static void MenuClicked()
        {
            string name = "WFrameWork" + DateTime.Now.ToString("yyyy_MMdd_HH"); //HH是24小时制 , hh是12小时制
            GUIUtility.systemCopyBuffer = name;
        }
    }
}