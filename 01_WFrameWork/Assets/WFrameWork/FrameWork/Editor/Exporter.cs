using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace WFramework
{
    public class Exporter
    {
        private static string GeneratepaPackageName()
        {
            return "WFrameWork_" + DateTime.Now.ToString("yyyy_MMdd_HH");
        }


        [MenuItem("WFramework/Framework/Editor/导出UnityPackage", false, 1)]
        private static void MenuClicked()
        {
            EditorUtil.ExportPackage("Assets/WFramework", GeneratepaPackageName() + ".unitypackage");
            EditorUtil.OPenInFolder(Path.Combine(Application.dataPath, "../"));
        }
    }
}