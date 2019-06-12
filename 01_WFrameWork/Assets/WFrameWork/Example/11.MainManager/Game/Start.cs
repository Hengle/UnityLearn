using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WFramework
{
    public class Start : MainManager
    {
        public static void LoadModule()
        {
            SceneManager.LoadScene("GameTest");
        }

        protected override void LauchInDevelopingMode()
        {
            //加载资源
            //初始化sdk
            //点击开始游戏
            Debug.Log("developing mode");
        }

        protected override void LaunchInTestMode()
        {
            Debug.Log("test mode");
        }

        protected override void LaunchInProductionMode()
        {
            Debug.Log("production mode");
        }
    }
}