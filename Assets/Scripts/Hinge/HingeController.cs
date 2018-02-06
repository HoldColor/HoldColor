using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class HingeController : MonoBehaviour {

	public GameObject ResourceUI;
    public GameObject GameBody;
    private Color Camp;

    private void Awake()
    {
        Camp = CampDefine.Orange;
        GameBody.GetComponent<SpriteRenderer>().color = Camp;
    }
}
