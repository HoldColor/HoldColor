using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class OtherObjectController : MonoBehaviour {
    public Color Camp;
    public string id;
	void Start () {
        
	}

    public void Init(Color camp)
    {
        Camp = camp;
        gameObject.GetComponent<SpriteRenderer>().color = Camp;
        gameObject.GetComponent<ColliderController>().Camp = Camp;
    }
}
