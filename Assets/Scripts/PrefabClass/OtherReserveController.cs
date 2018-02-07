using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class OtherReserveController : MonoBehaviour {
    public Color Camp;
	void Start () {
        Camp = CampDefine.Blue;
        gameObject.GetComponent<SpriteRenderer>().color = Camp;
        gameObject.GetComponent<ColliderController>().Camp = Camp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
