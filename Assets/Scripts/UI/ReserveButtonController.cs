using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReserveButtonController : MonoBehaviour {

    private Button BTN;
    private void Start()
    {
        BTN = gameObject.GetComponent<Button>();
        BTN.onClick.AddListener(StartTurretBuildTip);
    }

    private void StartTurretBuildTip()
    {
        GameObject RBT = Resources.Load<GameObject>("Prefabs/ReserveBuildTip");
        Instantiate(RBT);
        BTN.interactable = false;
    }
}
