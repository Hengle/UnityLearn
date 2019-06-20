using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using XLua;

public class test_03 : MonoBehaviour
{
    private LuaEnv _luaEnv;

    // Use this for initialization
    void Start()
    {
        _luaEnv = new LuaEnv();
        _luaEnv.AddLoader(MyLoader);
        _luaEnv.DoString("require 'LuaScript/Main/main'");
    }

    private byte[] MyLoader(ref string filePath)
    {
        string path;
#if UNITY_EDITOR
        path = Application.dataPath + "/" + filePath + ".lua.txt";
#endif
#if UNITY_ANDROID
        path = Application.streamingAsssetsPath+"/"+filePath+".lua.txt";
#endif
        return File.ReadAllBytes(path);
    }

    void OnDestroy()
    {
        if (_luaEnv != null)
        {
            _luaEnv.Dispose();
        }
    }
    
    
}

public class person
{
    public string name;
    public int age;
}