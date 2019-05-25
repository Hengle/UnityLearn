using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFramework
{
    public class MathUtilExample : MonoBehaviour
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFramework/Example/5.概率函数和随机函数", false, 5)]
#endif
        private static void MenuClicked()
        {
            Debug.Log(MathUtil.Percent(50));
            var randomAge = MathUtil.GetRandomValueFrom(
            1,2,3);
            Debug.Log(randomAge);
        }
    }
}