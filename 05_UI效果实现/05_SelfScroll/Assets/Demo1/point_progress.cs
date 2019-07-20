using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_progress : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Target;

    public Vector2 FinalPosition;

    [Range(0, 1)]
    public float progress = 0.0f;
    
    void Start()
    {
        if (Target)
        {
            FinalPosition = Target.GetComponent<RectTransform>().anchoredPosition;
        }

        if (FinalPosition != null)
        {
            Vector2 final = FinalPosition * progress;
            var rt = gameObject.GetComponent<RectTransform>();
            rt.anchoredPosition = final;
        }
    }
    
    

    void Update()
    {
        
    }
}
