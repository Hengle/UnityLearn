using UnityEngine;

namespace WFramework
{
    public partial class MathUtil
    {
        public static bool Percent(int percent)
        {
            return Random.Range(0, 100) <= percent;
        }


        public static T GetRandomValueFrom<T>(params T[] inputs)
        {
            return inputs[Random.Range(0, inputs.Length)];
        }
    }
}