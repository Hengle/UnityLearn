using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

/// <summary>
/// 资源加载服务类
/// </summary>
public class ResLoader
{
   
    public static List<Res> mResRecord = new List<Res>();
    
    private List<string> _selfRecord = new List<string>();
    public T LoadAsset<T>(string assetname) where T : Object
    {
        Res ret = null;
        ret = mResRecord.Find(res => res.Name == assetname);
        if(ret == null)
        {
            var obj = Resources.Load<T>(assetname);
            obj.name = assetname;
            ret = new Res(obj);
            mResRecord.Add(ret);
        }
        
        ret.Retain();
        _selfRecord.Add(ret.Name);
        return ret.Asset as T;
    }

    public void ReleaseAll()
    {
        for (int i = _selfRecord.Count - 1; i >= 0; i--)
        {
            Res temp = mResRecord.Find(res => res.Name == _selfRecord[i]);
            if (temp!=null)
            {
                Debug.Log("<color=green>走一次</color>");
                temp.Release();   
            }
        }
    }

    public int Count
    {
        get => mResRecord.Count;
    }
}
