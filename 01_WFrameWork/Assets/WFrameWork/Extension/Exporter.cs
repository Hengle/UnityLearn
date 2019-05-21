using System;
using UnityEditor;

namespace WFrameWork
{
    public class Exporter
    {
        public static string GeneratepaPackageName()
        {
            return "WFrameWork_" + DateTime.Now.ToString("yyyy_MMdd_HH");
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