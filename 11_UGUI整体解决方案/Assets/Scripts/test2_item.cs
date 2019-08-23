using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test2_item : MonoBehaviour
{
    private Image _image;

    public Image Image
    {
        get
        {
            if (_image == null)
                _image = GetComponent<Image>();
            return _image;
        }
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);

    }

    public void SetSprite(Sprite sprite)
    {

    }
}
