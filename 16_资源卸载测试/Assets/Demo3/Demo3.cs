using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo3 : MonoBehaviour
{
    private GameObject _obj;
    // Start is called before the first frame update
    void Start()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/Panel3");
        _obj = GameObject.Instantiate(prefab, this.transform);
    }

    private void OnDestroy()
    {
        
    }
}
