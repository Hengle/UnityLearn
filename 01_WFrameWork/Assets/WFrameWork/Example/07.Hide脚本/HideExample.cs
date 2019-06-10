using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class HideExample
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/7.Hide 脚本", false, 7)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;

            new GameObject().AddComponent<Hide>();
        }
#endif

    }
}