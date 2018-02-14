using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class FieldAreaController : MonoBehaviour {
    public GameObject FieldAreaDrawer;
    public GameObject FieldAreaCollider;
    private LineRenderer linerenderer;
    private BoxCollider2D ColliderComponent;
    private float _FieldSize;
    private int _AreaCount;
    private float _AreaWidth;
    private Color _AreaColor;

    private void Awake()
    {
        // AreaCircle
        linerenderer = FieldAreaDrawer.GetComponent<LineRenderer>();
        _AreaColor = Color.blue;
        _AreaWidth = 0.1f;
        _AreaCount = 4;
        _FieldSize = Field._HalfLength;

        linerenderer.startColor = _AreaColor;
        linerenderer.endColor = _AreaColor;
        linerenderer.startWidth = _AreaWidth;
        linerenderer.endWidth = _AreaWidth;

        Draw(_AreaCount, _FieldSize);
        // Collider

        ColliderComponent = FieldAreaCollider.GetComponent<BoxCollider2D>();
        ColliderComponent.size =new Vector2(_FieldSize * 2, _FieldSize * 2);
        ColliderComponent.isTrigger = true;
    }

    private void Draw(int Count, float Radius)
    {
        float x, y;
        linerenderer.positionCount = Count + 1;
        for (int i = 0; i < Count + 1; i++)
        {
            x = Mathf.Sin((45 + 360f * i / Count) * Mathf.Deg2Rad) * Radius * Mathf.Sqrt(2);
            y = Mathf.Cos((45 +360f * i / Count) * Mathf.Deg2Rad) * Radius * Mathf.Sqrt(2);
            linerenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }

    public void ShowArea()
    {
        FieldAreaDrawer.SetActive(true);
    }

    public void HideArea()
    {
        FieldAreaDrawer.SetActive(false);
    }
}
