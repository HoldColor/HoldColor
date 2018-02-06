using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class PlayerController : MonoBehaviour {
    public GameObject GameBody;
    public GameObject Path;
    public GameObject Interact;
    public GameObject Info;
    private Color Camp;
    private void Awake()
    {
        Camp = CampDefine.Orange;
        GameBody.GetComponent<SpriteRenderer>().color = Camp;
    }
}
