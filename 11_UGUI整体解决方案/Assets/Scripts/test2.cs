using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test2 : MonoBehaviour
{
    public Vector2 _sizeDelta;

    public Sprite[] ItemSprites;

    private List<test2_item> items = null;

    private void Start()
    {
        items = new List<test2_item>();
        CreateItem();
    }

    private GameObject CreateTemplate()
    {
        GameObject item = new GameObject("Template");
        item.AddComponent<RectTransform>().sizeDelta = _sizeDelta;
        item.AddComponent<Image>();
        item.AddComponent<test2_item>();
        return item;
    }

    private void CreateItem()
    {
        GameObject template = CreateTemplate();
        test2_item item_temp = null;
        foreach (Sprite sprite in ItemSprites)
        {
            item_temp = Instantiate(template).GetComponent<test2_item>();
            item_temp.SetParent(transform);
            item_temp.SetSprite(sprite);
            items.Add(item_temp);
        }
    }
 
}
