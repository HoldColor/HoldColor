using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretButtonController : MonoBehaviour {
    private Button BTN;
    private void Start()
    {
        BTN = gameObject.GetComponent<Button>();
        BTN.onClick.AddListener(StartTurretBuildTip);
    }

    private void StartTurretBuildTip ()
    {
        GameObject TBT = Resources.Load<GameObject>("Prefabs/TurretBuildTip");
        Instantiate(TBT);
        BTN.interactable = false;
    }
}
