using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class test_02 : MonoBehaviour
{
	private LuaEnv _luaEnv;
	// Use this for initialization
	void Start () {
		_luaEnv = new LuaEnv();
		_luaEnv.DoString("CS.UnityEngine.Debug.Log('hello world2!')");
	}

	void OnDestroy()
	{
		_luaEnv?.Dispose();
	}
}
