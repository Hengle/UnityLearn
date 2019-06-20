using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class test_03 : MonoBehaviour
{

	private LuaEnv _luaEnv;
	// Use this for initialization
	void Start () {
		_luaEnv = new LuaEnv();
		_luaEnv.DoString("require 'my_byfile'");
//		_luaEnv.Tick();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
