using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WFramework
{
    public class LevelManager
    {
        private static List<string> _mLevelNames;

        public static int Index { get; set; }

        public static void Init(List<string> levelNames)
        {
            _mLevelNames = levelNames;
            Index = 0;
        }

        public static void LoadCurrent()
        {
            SceneManager.LoadScene(_mLevelNames[Index]);
        }

        public static void LoadNext()
        {
            Index++;
            if (Index >= _mLevelNames.Count)
            {
                Index = 0;
            }
            SceneManager.LoadScene(_mLevelNames[Index]);
        }

    }
}