using System.Collections;
using UnityEngine;

public class UnloadResourcesExample : MonoBehaviour
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Example/01.UnloadResources", false, 19)]
#endif
    static void MenuItem()
    {
        UnityEditor.EditorApplication.isPlaying = true;
    }
}
