using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UILayers
{
    SceneLayer,        //场景UI，如点击建筑查看建筑信息提示
    BackgroundLayer,    //背景UI
    NormalLayer,        //普通UI（一级，二级，三级等窗口，用户主要交互界面）
    NavigationLayer,    //导航条UI（只在主要UI界面显示）
    InfoLayer,          //信息UI（导航条，广播等）
    TipLayer,           //提示类UI（错误信息，网络断开联机提示等）
    TopLayer,           //顶层UI，（场景加载等）
}


public abstract class Layer {
    protected string name;
    protected int plane_distance;
    protected int order_in_layer;
}

public sealed class SceneLayer : Layer
{
    private static SceneLayer scenelayer;
    private SceneLayer()
    {
        name = "SceneLayer";
        plane_distance = 1100;
        order_in_layer = 0;
    }

    public string Name { get => name ;}
    public int PlaneDistance { get => plane_distance; }
    public int OrderInLayer { get => order_in_layer; }
}


public sealed class BackgroundLayer:Layer
{
    
}



