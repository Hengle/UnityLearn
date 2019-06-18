using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public static class StaticThisExtension
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/18.StaticThisExtension", false, 18)]
#endif
        static void MenuItem()
        {
            new object().Test();
            "string".Test();
        }

        static void Test(this object selfObj)
        {
            Debug.Log(selfObj);
        }
    }
}
