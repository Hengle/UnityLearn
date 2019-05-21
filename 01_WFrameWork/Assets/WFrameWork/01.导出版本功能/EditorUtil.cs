using System;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif


namespace WFrameWork
{
    public class EditorUtil
    {
        public static string GeneratepaPackageName()
        {
            return "WFrameWork_" + DateTime.Now.ToString("yyyy_MMdd_HH");
        }


        public static void CopyText2Clip(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }

        public static void OPenInFolder(string path)
        {
            Application.OpenURL("file://" + path);
        }
#if UNITY_EDITOR
        public static void ExPortPackage()
        {
            AssetDatabase.ExportPackage("Assets/WFrameWork", GeneratepaPackageName() + ".unitypackage",
                ExportPackageOptions.Recurse);
        }

        public static void CallMenuItem(string menuPath)
        {
            EditorApplication.ExecuteMenuItem(menuPath);
        }
#endif
    }
}