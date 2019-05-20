using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace WFrameWork
{
    public class OpenTargetFolder
    {
        #if UNITY_EDITOR
        [MenuItem("WFrameWork/4.打开所在的文件夹")]
        private static void ExportPackageInFolder()
        {
            Application.OpenURL("file://" + Path.Combine(Application.dataPath,"../") );
        }
        #endif
    }
}