using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchDemo : MonoBehaviour
{
    public Text infoText;
    
    void Start()
    {
        
    }

    void Update()
    {
        //获取当前Touch对象的个数
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0]; //获得第一个touch对象
        }
    }
}
