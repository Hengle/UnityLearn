using UnityEngine;
using Random = UnityEngine.Random;

namespace WFrameWork
{
    public partial class MathUtil
    {
        //随机获取object 中的某一个
        //泛型：结构中的部分或者全部类型都可以先不进行定义，而是等到调用的时候再去定义
        //方法：逻辑上的复用， 泛型结构上的复用
        //params： 方法 如果传入的是一个数组，那么 参数本省就是一个数组，如果传入的是若干个值，那么values重包含了这若干个值
        public static T GetRandomValueFrom<T>(params T[] values)
        {
            return values[Random.Range(0, values.Length)];
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("WFrameWork/04.泛型设计",false,4)]
#endif
        private static void MenuClicked()
        {
            Debug.Log(GetRandomValueFrom(1, 2, 3));
            Debug.Log(GetRandomValueFrom("ad", "dfasd", "fasdfas"));
            Debug.Log(GetRandomValueFrom(0.1f, 0.5f, 2.1f));
        }
    }
}