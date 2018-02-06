using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathController : MonoBehaviour {
    private LineRenderer linerenderer;
    private Color LineColor;
	// Use this for initialization
	void Start () {
        linerenderer = this.gameObject.GetComponent<LineRenderer>();
        LineColor = new Color(76f / 175f, 158f / 255f, 80f / 255f, 0.8f);
        linerenderer.startColor = LineColor;
        linerenderer.endColor = LineColor;
        linerenderer.startWidth = 0.1f;
        linerenderer.endWidth = 0.1f; 
	}
	
	// Update is called once per frame
	public void draw (Vector3[] path) {
        linerenderer.SetPosition(0, path[0]);
        linerenderer.SetPosition(1, path[1]);
	}
}
