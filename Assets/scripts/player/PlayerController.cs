using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class PlayerController : MonoBehaviour {
    public GameObject GameBody;
    public GameObject Path;
    public GameObject Interact;
    public GameObject Info;
    private Color _camp;
    public Color Camp
    {
        get {
            return _camp;
        }
    }
    private void Start()
    {
        Debug.Log("Player");
        _camp = GameObject.Find("InitializeController").GetComponent<Initialize>().Camp;
        GameBody.GetComponent<SpriteRenderer>().color = _camp;
    }
}
