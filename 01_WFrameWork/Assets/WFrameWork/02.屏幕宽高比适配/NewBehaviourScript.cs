#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace WFrameWork
{
    public class ScreenJudge01
    {
#if UNITY_EDITOR
        [MenuItem("WFrameWork/02.屏幕相关/1.屏幕宽高比判断")]
#endif
        private static void MenuClicked()
        {
            var isLandscap = JudgeScreen();

            Debug.Log(isLandscap ? "横屏" : "竖屏");
        }
        
        
        /// <summary>
        /// 判断是否是横屏
        /// </summary>
        /// <returns>true: 横屏  false:竖屏</returns>
        public static bool JudgeScreen()
        {
            return Screen.width > Screen.height;
        }
        
#if UNITY_EDITOR
        [MenuItem("WFrameWork/07.屏幕相关/2.输出屏幕比值")]
#endif
        private static void MenuClicked2()
        {
            var isLandscap = JudgeScreen();
            float aspect;
            if (isLandscap)
            {
                aspect = (float) Screen.width / Screen.height;
            }
            else
            {
                aspect = (float) Screen.height/Screen.width;
            }

            Debug.Log(aspect);
        }
    }
}