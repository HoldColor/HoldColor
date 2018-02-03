using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;
public class PlayerInteractController : MonoBehaviour {
    public LineRenderer linerenderer;
    public int Count;
    public float Radius;
	// Use this for initialization
	void Start () {
        linerenderer = this.GetComponent<LineRenderer>();
        linerenderer.startColor = Color.blue;
        linerenderer.endColor = Color.blue;
        linerenderer.startWidth = 0.1f;
        linerenderer.endWidth = 0.1f;
        Count = 100;
        Radius = PlayerConfig._InteractRadius;
        Draw(Count, Radius);
	}
	
	private void Draw(int Count, float Radius)
    {
        float x, y;
        linerenderer.positionCount = Count + 1;
        for (int i = 0; i < Count +1; i++)
        {
            x = Mathf.Sin((360f * i / Count) * Mathf.Deg2Rad) * Radius;
            y = Mathf.Cos((360f * i / Count) * Mathf.Deg2Rad) * Radius;
            linerenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}
