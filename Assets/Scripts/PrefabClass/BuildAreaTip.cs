using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAreaTip : MonoBehaviour {
    private LineRenderer linerenderer;
    private Color color;
    private float width;
    private float radius;
    private int count;
    public float Radius
    {
        get
        {
            return radius;
        }
        set
        {
            radius = value;
            Draw(count, value);
        }
    }
    // Use this for initialization
    void Awake () {
        linerenderer = gameObject.GetComponent<LineRenderer>();
        color = Color.gray;
        width = 0.1f;
        count = 200;
        linerenderer.startColor = color;
        linerenderer.endColor = color;
        linerenderer.startWidth = width;
        linerenderer.endWidth = width;
        Draw(count, radius);
    }

    private void Draw(int Count, float Radius)
    {
        float x, y;
        linerenderer.positionCount = Count + 1;
        for (int i = 0; i < Count + 1; i++)
        {
            x = Mathf.Sin((360f * i / Count) * Mathf.Deg2Rad) * Radius;
            y = Mathf.Cos((360f * i / Count) * Mathf.Deg2Rad) * Radius;
            linerenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
