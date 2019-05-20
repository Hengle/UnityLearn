#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

#endif

namespace WFrameWork
{
    public class MenuItemReuse
    {
#if UNITY_EDITOR
        [MenuItem("WFrameWork/5.MenuItem复用 %e")]
        private static void MenuItemReuseTest()
        {
            EditorApplication.ExecuteMenuItem("WFrameWork/3.导出WFrameWork为UnityPackage");
            Application.OpenURL("file://" + Path.Combine(Application.dataPath, "../"));
        }
#endif
    }
}