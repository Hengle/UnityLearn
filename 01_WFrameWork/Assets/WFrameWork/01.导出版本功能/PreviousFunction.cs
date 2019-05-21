using System;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif


namespace WFrameWork
{
    public class PreviousFunction
    {
        public static string GeneratepaPackageName()
        {
            return "WFrameWork_" + DateTime.Now.ToString("yyyy_MMdd_HH");
        }


        public static void CopyText2Clip(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }


        public static void ExPortPackage()
        {
            AssetDatabase.ExportPackage("Assets/WFrameWork", GeneratepaPackageName() + ".unitypackage",
                ExportPackageOptions.Recurse);
        }


        public static void OPenInFolder(string path)
        {
            Application.OpenURL("file://" + path);
        }


#if UNITY_EDITOR
        [MenuItem("WFrameWork/01导出功能/1.生成UnityPacakge 名字")]
        private static void MenuClicked()
        {
            Debug.Log(GeneratepaPackageName());
        }

        [MenuItem("WFrameWork/01导出功能/2.复制文件名到剪贴板")]
        private static void MenuClicked3()
        {
            CopyText2Clip(GeneratepaPackageName());
        }


        [MenuItem("WFrameWork/01导出功能/3.导出UnityPackage %e")]
        private static void MenuClicked4()
        {
            ExPortPackage();
            OPenInFolder(Path.Combine(Application.dataPath, "../"));
        }

#endif
    }
}