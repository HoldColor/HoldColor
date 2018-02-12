using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class ResourceBuff : MonoBehaviour {
    private SFController OwnController;
    private SFInteractAction action;
    private HingeProducingResourceController HPRC;
    private GameObject RC;
    // Use this for initialization
    void Start()
    {
        OwnController = gameObject.GetComponent<SFController>();
        action = OwnController.Interact.GetComponent<InteractController>().InteractCollider.GetComponent<SFInteractAction>();
        OwnController.type = SFController.SFType.Resource;
        RC = gameObject.transform.Find("ProducingTip/ResourceTips").gameObject;
        HPRC = RC.GetComponent<HingeProducingResourceController>();
        HPRC.Cycle = ResourceSF._AddResourceCycle;
        HPRC.ResourceByCycle = ResourceSF._AddResourceByCycle;
    }

    public void AddResource()
    {
        HPRC.StartAnimation();
    }

    public void CloseBuff()
    {
        HPRC.StopAnimation();
    }
}
