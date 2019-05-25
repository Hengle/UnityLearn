using UnityEngine;

namespace WFramework
{
    [System.Obsolete("在2017版本 Editor 中 ,屏幕宽高判断出错,其他版本未判断 , 这个类相关的方法停用")]
    public partial class ResolutionCheck
    {
        public static float GetAspectRatio()
        {
            var isLandscape = Screen.width > Screen.height;
            return isLandscape ? (float) Screen.width / Screen.height : (float) Screen.height / Screen.width;
        }

        public static bool IsPadResolution()
        {
            return InAspectRange(4.0f / 3);
        }

        public static bool IsPhoneResolution()
        {
            return InAspectRange(16.0f / 9);
        }

        public static bool IsPhone15Resolution()
        {
            return InAspectRange(3.0f / 2);
        }

        public static bool IsiPhoneXResolution()
        {
            return InAspectRange(2436.0f / 1125);
        }


        public static bool InAspectRange(float dstAspectRatio)
        {
            var aspect = GetAspectRatio();
            return aspect > (dstAspectRatio - 0.05) && aspect < (dstAspectRatio + 0.05);
        }
    }
}