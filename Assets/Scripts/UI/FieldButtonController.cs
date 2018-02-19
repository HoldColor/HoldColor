﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldButtonController : MonoBehaviour {

    private Button BTN;
    private void Start()
    {
        BTN = gameObject.GetComponent<Button>();
        BTN.onClick.AddListener(StartTurretBuildTip);
    }

    private void StartTurretBuildTip()
    {
        GameObject FBT = Resources.Load<GameObject>("Prefabs/FieldBuildTip");
        Instantiate(FBT);
        BTN.interactable = false;
    }
}
