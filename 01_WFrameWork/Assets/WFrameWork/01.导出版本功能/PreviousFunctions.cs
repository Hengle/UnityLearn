using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using WFrameWork;

public class PreviousFunctions
{
#if UNITY_EDITOR

    [MenuItem("WFrameWork/01.导出WFrameWork为unitypackage %e")]
    private static void MenuClicked4()
    {
        EditorUtil.ExPortPackage();
        EditorUtil.OPenInFolder(Path.Combine(Application.dataPath, "../"));
    }

#endif
}