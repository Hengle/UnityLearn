using System.Collections;
using System.Collections.Generic;
using UIExtension;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public EnchanceScrollView enchance;

    public Button Fir;

    public Button Move;

    public void Start()
    {
        Fir.onClick.AddListener(StartScroll);
        Move.onClick.AddListener(MoveClick);
        enchance.AddRefresh(ListenerRefresh);
    }
    
    
    private void StartScroll() {
        enchance.SetNum(30);
    }


    private void MoveClick()
    {
        enchance.MoveToIndex(20,1);
    }

    private void ListenerRefresh(int index, GameObject obj)
    {
        Button btn = obj.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        Text txt = obj.GetComponentInChildren<Text>();

        txt.text = index.ToString();
        btn.onClick.AddListener(() => { Debug.Log("点击的是第 " + index+ "个");});
    }

}
