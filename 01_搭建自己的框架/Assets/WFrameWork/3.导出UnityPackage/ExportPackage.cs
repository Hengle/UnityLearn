using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace WFrameWork
{
    public class ExportPackage
    {
#if UNITY_EDITOR
        [MenuItem("WFrameWork/3.导出WFrameWork为UnityPackage")]
        private static void MenuClicked()
        {
//            Debug.Log(Application.);
            string file_name = "WFrameWork" + DateTime.Now.ToString("yyyy_MMdd_HH") + ".unitypackage";

            AssetDatabase.ExportPackage("Assets/WFrameWork", file_name, ExportPackageOptions.Recurse);
        }
#endif
    }
}