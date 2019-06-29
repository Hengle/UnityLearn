using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ABCreate : MonoBehaviour
{
    public static string ABCONFIG_PATH = "Assets/FrameWork/Editor/ABConfig.asset"; 
	[MenuItem("Tools/打包")]
	public static void MenuClicked()
	{
		//1.吧写的ABConfig读取出来
        ABConfig abconfig = AssetDatabase.LoadAssetAtPath<ABConfig>(ABCONFIG_PATH);

        //test
        foreach(var str in abconfig.m_AllPrefab){
            Debug.Log(str);
        }

        foreach(var item in abconfig.m_AllFileDirAb)
        {
            Debug.Log(item.AbName + "   " + item.Path);
        }

	}
}
