using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class helloword01 : MonoBehaviour
{

	private LuaEnv _luaEnv;
	void Start()
	{
		_luaEnv = new LuaEnv();
		_luaEnv.DoString("print('hello world!')");
		_luaEnv.Dispose();
	}

	void OnDestroy()
	{
		_luaEnv.Dispose();
	}
}

