using System;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace WFrameWork
{
    public class PreviousFunction
    {
#if UNITY_EDITOR
        [MenuItem("WFrameWork/06.总结之前的功能/1.生成UnityPacakge 名字")]
#endif
        private static void MenueClicked()
        {
            Debug.Log(GeneratepaPackageName());
        }

        public static string GeneratepaPackageName()
        {
            return "WFrameWork_" + DateTime.Now.ToString("yyyy_MMdd_HH");
        }


#if UNITY_EDITOR
        [MenuItem("WFrameWork/06.总结之前的功能/2.复制文本到剪贴板")]
#endif
        private static void MenuClicked2()
        {
            CopyText2Clip("需要复制到剪贴板的文字");
        }

        public static void CopyText2Clip(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }


#if UNITY_EDITOR
        [MenuItem("WFrameWork/06.总结之前的功能/3.复制文件名到剪贴板")]
#endif
        private static void MenuClicked3()
        {
            CopyText2Clip(GeneratepaPackageName());
        }

        
#if UNITY_EDITOR
        [MenuItem("WFrameWork/06.总结之前的功能/4.导出UnityPackage")]
#endif
        private static void MenuClicked4()
        {
            ExPortPackage();
            OpenURL();
        }

        public static void ExPortPackage()
        {
            AssetDatabase.ExportPackage("Assets/WFrameWork", GeneratepaPackageName() + ".unitypackage",
                ExportPackageOptions.Recurse);
        }

        public static void OpenURL()
        {
            Application.OpenURL("file://" + Path.Combine(Application.dataPath, "../"));
        }
    }
}