using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class AudioExample : MonoBehaviourSimplify
    {
       
        #if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/13.AudioManager")]
        static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("AudioExample")
                .AddComponent<AudioExample>();
        }
#endif

        protected override void OnBeforeDestroy()
        {
        }

        private void Start()
        {
            AudioManager.Instance.PlaySound("coin");
            AudioManager.Instance.PlaySound("coin");

            Delay(1.0f, () => { AudioManager.Instance.PlayMusic("home", true); });
            Delay(3.0f, AudioManager.Instance.PauseMusic);

        }
    }
}