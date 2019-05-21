#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace WFrameWork
{
    public class ProbabilityFunc
    {
#if UNITY_EDITOR
        [MenuItem("WFrameWork/10.随机概率函数")]
#endif
        private static void MenuClicked()
        {
            Debug.Log(Percent(50));
        }

        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }
    }
}