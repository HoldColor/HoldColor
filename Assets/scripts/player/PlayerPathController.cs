using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathController : MonoBehaviour {
    private LineRenderer linerenderer;
	// Use this for initialization
	void Start () {
        linerenderer = this.gameObject.GetComponent<LineRenderer>();
        linerenderer.startColor = Color.red;
        linerenderer.endColor = Color.red;
        linerenderer.positionCount = 2;
        linerenderer.startWidth = 0.1f;
        linerenderer.endWidth = 0.1f; 
	}
	
	// Update is called once per frame
	public void draw (Vector3[] path) {
        linerenderer.SetPosition(0, path[0]);
        linerenderer.SetPosition(1, path[1]);
	}
}
