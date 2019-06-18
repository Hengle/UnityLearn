using UnityEngine;

namespace WFramework
{
    public class MonoSingletonExample : MonoSingleton<MonoSingletonExample>
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/17.MonoSingletonExample", false, 17)]
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