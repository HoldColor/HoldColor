using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class SFController : MonoBehaviour {
    public GameObject GameBody;
    public GameObject Info;
    public GameObject BodyCollider;
    public GameObject BuffController;
    public GameObject Interact;
    public Color Camp;
	// Use this for initialization
	void Start () {
        Camp = CampDefine.Campless;
        GameBody.GetComponent<SpriteRenderer>().color = Camp;
        BodyCollider.GetComponent<ColliderController>().Camp = Camp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
