using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAreaTip : MonoBehaviour {
    public enum BuildType
    {
        Turret,
        Field,
        Reserve
    }
    public BuildType Type;
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
        switch (Type)
        {
            case BuildType.Turret:
                linerenderer.positionCount = Count + 1;
                for (int i = 0; i < Count + 1; i++)
                {
                    x = Mathf.Sin((360f * i / Count) * Mathf.Deg2Rad) * Radius;
                    y = Mathf.Cos((360f * i / Count) * Mathf.Deg2Rad) * Radius;
                    linerenderer.SetPosition(i, new Vector3(x, y, 0));
                }
                break;
            case BuildType.Field:
                Count = 4;
                linerenderer.positionCount = Count + 1;
                for (int i = 0; i < Count + 1; i++)
                {
                    x = Mathf.Sin((45 + 360f * i / Count) * Mathf.Deg2Rad) * Radius * Mathf.Sqrt(2);
                    y = Mathf.Cos((45 + 360f * i / Count) * Mathf.Deg2Rad) * Radius * Mathf.Sqrt(2);
                    linerenderer.SetPosition(i, new Vector3(x, y, 0));
                }
                break;
            case BuildType.Reserve:
                linerenderer.positionCount = Count + 1;
                for (int i = 0; i < Count + 1; i++)
                {
                    x = Mathf.Sin((360f * i / Count) * Mathf.Deg2Rad) * Radius;
                    y = Mathf.Cos((360f * i / Count) * Mathf.Deg2Rad) * Radius;
                    linerenderer.SetPosition(i, new Vector3(x, y, 0));
                }
                break;
        }
        
    }
}
