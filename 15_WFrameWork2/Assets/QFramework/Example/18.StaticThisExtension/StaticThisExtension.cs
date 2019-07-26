using UnityEngine;

namespace QFramework
{
    public static class StaticThisExtension
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("QFramework/Example/18.StaticThisExtension", false, 18)]
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