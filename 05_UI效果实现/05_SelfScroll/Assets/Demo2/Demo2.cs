using UnityEngine;
using UnityEngine.UI;

public class Demo2 : MonoBehaviour {

    public void SetText (string v) {
        GetComponent<ButtonEx> ().text = v;
        Debug.Log ("SetText: " + v);
    }


}