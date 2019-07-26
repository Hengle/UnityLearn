using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadPrefabTest : MonoBehaviour
{
    public Canvas cav;

    private GameObject _ui_obj;
    void Start()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/RawImage");
        _ui_obj = GameObject.Instantiate(prefab, cav.transform);
        StartCoroutine(UnLoadTest());
    }


    IEnumerator UnLoadTest()
    {
        Debug.Log("等待5秒");
        yield return  new WaitForSeconds(5);
        Debug.Log("不销毁物体只调用卸载方法");
        Resources.UnloadUnusedAssets();
        yield return new WaitForSeconds(5);
        Debug.Log("先销毁物体");
        Destroy(_ui_obj);
        yield return  new WaitForSeconds(5);
        Resources.UnloadUnusedAssets();

    }
}
