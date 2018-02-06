using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;
public class PlayerInteractController : InteractArea {

    private void Start()
    {
        Debug.Log(GameObject.Find("PlayerController").GetComponent<PlayerController>().Camp);
        Color = GameObject.Find("PlayerController").GetComponent<PlayerController>().Camp;
    }
}
