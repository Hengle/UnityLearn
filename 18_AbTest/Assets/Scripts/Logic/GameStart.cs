using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button _startBtn;

    void Start()
    {
        _startBtn.onClick.AddListener(() => { StartCoroutine(StartGame()); });
        
    }



    //开始游戏加载打包好的场景
    private IEnumerator StartGame()
    {
        Debug.Log("调用到这里");
        string name = "/Scenes/TestScene.assetbundle";
        string path = "file://" + Application.streamingAssetsPath + name;
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(path);
        yield return www.SendWebRequest();

        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);

            SceneManager.LoadSceneAsync("TestScene");

        }


    }
}
