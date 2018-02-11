using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class ShieldBuff : MonoBehaviour {
    private SFController OwnController;
    private SFInteractAction action;
	// Use this for initialization
	void Start () {
        OwnController = gameObject.GetComponent<SFController>();
        action = OwnController.Interact.GetComponent<InteractController>().InteractCollider.GetComponent<SFInteractAction>();
        OwnController.type = SFController.SFType.Shield;
	}
	
	public void RestoreShield()
    {
        foreach (Collider2D c in action.BodyCollisions)
        {
            ColliderController cc = c.gameObject.GetComponent<ColliderController>();
            if (cc.Camp == OwnController.Camp)
            {
                if (cc.Info.GetComponent<StateBar>().IsShield)
                {
                    cc.Info.GetComponent<StateBar>().RestoreShield(ShieldSF._RestoreShieldBySecond);
                } else
                {
                    cc.Info.GetComponent<StateBar>().IsShield = true;
                }
            }
        }
    }
}
