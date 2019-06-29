using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ABConfig" , menuName = "CreateAbConfig" , order = 0 )]
public class ABConfig:ScriptableObject
{
    
    //单个文件所在文件夹路径，会遍历文件夹下的所有prefab, 所有的prefab 的名字不能重复，保证名字的唯一性
    public List<string> m_AllPrefab = new List<string>();

    public List<FileDirAbName> m_AllFileDirAb = new List<FileDirAbName>();


    [System.Serializable]
    public struct FileDirAbName{
        public string AbName;
        public string Path;
    }

}
