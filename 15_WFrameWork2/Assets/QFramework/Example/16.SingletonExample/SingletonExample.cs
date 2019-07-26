using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
    public class SingletonExample : Singleton<SingletonExample>
    {
        private SingletonExample()
        {
            Debug.Log("singleton example ctor");
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("QFramework/Example/16.SingletonExample", false, 16)]
#endif
        static void MenuClicked()
        {
            var initInstance = SingletonExample.Instance;
            initInstance = SingletonExample.Instance;
        }
    }
}