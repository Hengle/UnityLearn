using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchDemo : MonoBehaviour
{
    public Text infoText;

    private string info;
    
    void Start()
    {
        
    }

    void Update()
    {
        info = string.Empty;
        //获取当前Touch对象的个数
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0]; //获得第一个touch对象
            info = "fingerId: "+myTouch.fingerId+"\n";  //fingerId 用来识别当前手指的唯一标识
            info += "deltaPosition: " + myTouch.deltaPosition + "\n";  //当前位置与上次位置之间的差值
            info += "deltaTime: " + myTouch.deltaTime + "\n";  //本次纪录Touch对象与上次纪录Touch状态之间的时间差
            info += "deltaPosition:" + myTouch.tapCount + "\n";  //touch对象所对应的手指点击屏幕的次数
            //phase 标识当前手指对应的Touch对象的状态
            info += "phase: " + myTouch.phase + "\n";
            
            
        }

        infoText.text = info;
    }
}
