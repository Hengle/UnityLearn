using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attrTest : Graphic
{
  
    public List<Transform> points;

    private LineRenderer line;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        SetAllDirty();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        if (points == null) return;

        Color32 color32 = color;
        vh.Clear();

        int index = 0;
        if (!line)
        {
            line = GetComponent<LineRenderer>();
        }

        foreach (var point in points)
        {
            vh.AddVert(point.localPosition, color32, new Vector2(0,0));
            if (line)
            {
                line.SetPosition(index++,point.localPosition);
            }
        }
        
        //闭合Line
        if (line)
        {
            line.SetPosition(index, points[0].localPosition);
        }

        for (int i = 0; i < points.Count-2; i++)
        {
            vh.AddTriangle(0, i+1, i+2);
        }
        
    }



}
