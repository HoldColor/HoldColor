using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour {

    public LineRenderer linerenderer;
    private int _count;
    private float _radius;
    private Color _color;
    private float _width;
    public int Count
    {
        get
        {
            return _count;
        }
        set
        {
            _count = value;
            Draw(_count, _radius);
        }
    }
    public float Radius
    {
        get
        {
            return _radius;
        }
        set
        {
            _radius = value;
            Draw(_count, _radius);
        }
    }
    public Color Color
    {
        get
        {
            return _color;
        }
        set
        {
            _color = value;
            linerenderer.startColor = value;
            linerenderer.endColor = value;
        }
    }
    public float Width
    {
        get
        {
            return _width;
        }
        set
        {
            _width = value;
            linerenderer.startWidth = value;
            linerenderer.endWidth = value;
        }
    }
    private void Awake()
    {
        linerenderer = this.GetComponent<LineRenderer>();
        linerenderer.startColor = Color.blue;
        linerenderer.endColor = Color.blue;
        linerenderer.startWidth = 0.1f;
        linerenderer.endWidth = 0.1f;
        _count = 100;
        _radius = 10f;
        Draw(_count, _radius);
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
