using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class HingeController : MonoBehaviour {

	public GameObject ResourceUI;
    public GameObject GameBody;
    private Color _camp;
    public Color Camp
    {
        get
        {
            return _camp;
        }
    }
    private void Start()
    {
        _camp = GameObject.Find("InitializeController").GetComponent<Initialize>().Camp;
        GameBody.GetComponent<SpriteRenderer>().color = _camp;
    }
}
