﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
    public class MonoSingletonExample : MonoSingleton<MonoSingletonExample>
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("QFramework/Example/17.MonoSingletonExample",false,17)]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
        }
#endif

        [RuntimeInitializeOnLoadMethod]
        static void Example()
        {
            var initInstance = MonoSingletonExample.Instance;
            initInstance = MonoSingletonExample.Instance;
        }
    }
}