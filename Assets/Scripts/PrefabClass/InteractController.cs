using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class InteractController : MonoBehaviour {
    private LineRenderer linerenderer;
    public GameObject InteractArea;
    public GameObject InteractCollider;
    private CircleCollider2D ColliderComponent;
    private float _interactRadius;
    private int _interactAreaCount;
    private float _interactAreaWidth;
    private Color _interactAreaColor;
    public float InteractRadius
    {
        get { return _interactRadius; }
        set
        {
            _interactRadius = value;
            Draw(_interactAreaCount, value);
            ColliderComponent.radius = value;
        }
    }
    public float InteractAreaWidth
    {
        get { return _interactAreaWidth; }
        set
        {
            _interactAreaWidth = value;
            linerenderer.startWidth = value;
            linerenderer.endWidth = value;
        }
    }
    public Color InteractAreaColor
    {
        get { return _interactAreaColor; }
        set
        {
            _interactAreaColor = value;
            linerenderer.startColor = value;
            linerenderer.endColor = value;
        }
    }
	// Use this for initialization
	private void Awake () {
        // AreaCircle
        linerenderer = InteractArea.GetComponent<LineRenderer>();
        _interactAreaColor = CampDefine.Campless;
        _interactAreaWidth = 0.1f;
        _interactAreaCount = 100;
        _interactRadius = 10f;

        linerenderer.startColor = _interactAreaColor;
        linerenderer.endColor = _interactAreaColor;
        linerenderer.startWidth = _interactAreaWidth;
        linerenderer.endWidth = _interactAreaWidth;
        
        Draw(_interactAreaCount, _interactRadius);
        // Collider

        ColliderComponent = InteractCollider.GetComponent<CircleCollider2D>();
        ColliderComponent.radius = _interactRadius;
        ColliderComponent.isTrigger = true;
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

    public void ShowArea()
    {
        InteractArea.SetActive(true);
    }

    public void HideArea()
    {
        InteractArea.SetActive(false);
    }
}
