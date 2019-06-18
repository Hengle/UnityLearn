using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class GUIExample : MonoBehaviourSimplify
    {
        protected override void OnBeforeDestroy()
        {
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/12.GUIManager",false, 12)]
        static void MunClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("GUIExample")
                .AddComponent<GUIExample>();
        }
#endif

        void Start()
        {
            GUIManager.SetResolution(1280, 720, 0);
            GUIManager.LoadPanel("HomePanelTest", UILayer.Common);
            Delay(3.0f, () => { GUIManager.UnLoadPanel("HomePanelTest"); });
        }
    }
}