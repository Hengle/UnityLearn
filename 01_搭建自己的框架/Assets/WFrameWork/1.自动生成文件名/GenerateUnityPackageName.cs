﻿using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace WFrameWork
{
    public class GenerateUnityPackageName : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("WFrameWork/1.生成UnityPacakge 名字")]
#endif
        static void MenueClicked()
        {
            Debug.Log("WFrameWork_" + DateTime.Now.ToString("yyyy_MMdd_hh"));
        }
    }
}