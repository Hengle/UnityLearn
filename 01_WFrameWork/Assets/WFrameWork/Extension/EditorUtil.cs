using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif


namespace WFrameWork
{
    public partial class EditorUtil
    {
        public static void CopyText2Clip(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }

        public static void OPenInFolder(string path)
        {
            Application.OpenURL("file://" + path);
        }

#if UNITY_EDITOR
        public static void CallMenuItem(string menuPath)
        {
            EditorApplication.ExecuteMenuItem(menuPath);
        }
#endif
    }
}