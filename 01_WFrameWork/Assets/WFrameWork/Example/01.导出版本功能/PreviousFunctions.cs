using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using WFrameWork;

public class PreviousFunctions
{
#if UNITY_EDITOR

    [MenuItem("WFrameWork/01.导出WFrameWork为unitypackage %e" , false, 1)]
    private static void MenuClicked4()
    {
        Exporter.ExPortPackage();
        EditorUtil.OPenInFolder(Path.Combine(Application.dataPath, "../"));
    }

#endif
}