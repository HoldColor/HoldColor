using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoldColor.Config;

public class HingeProducingResourceController : MonoBehaviour {

    private Animator animator;
    private AddResource addResource;
    private Text ResourceValueUI;
    private int _resourceByCycle;
    private float _cycle;
    public int ResourceByCycle
    {
        get
        {
            return _resourceByCycle;
        }
        set
        {
            _resourceByCycle = value;
            ResourceValueUI.text = "Resource +" + _resourceByCycle;
            addResource.resource = value;
        }
    }
    public float Cycle
    {
        get
        {
            return _cycle;
        }
        set
        {
            _cycle = value;
            float ProductingSpeed = 1 / value;
            animator.SetFloat("ProductingSpeed", ProductingSpeed);
        }
    }

    // Use this for initialization
    void Awake() {
        ResourceValueUI = gameObject.GetComponent<Text>();
        animator = gameObject.GetComponent<Animator>();
        addResource = animator.GetBehaviour<AddResource>();
        animator.SetBool("IsStart", false);
        _resourceByCycle = HingeConfig._AddResourceByCycle;
        _cycle = HingeConfig._AddResourceCycle;
        addResource.resource = _resourceByCycle;
        ResourceValueUI.text = "Resource +" + _resourceByCycle;
        ResourceValueUI.enabled = false;
        float ProductingSpeed = 1 / _cycle;
        animator.SetFloat("ProductingSpeed", ProductingSpeed);
    }

    public void StartAnimation()
    {
        ResourceValueUI.enabled = true;
        animator.SetBool("IsStart", true);
    }

    public void StopAnimation()
    {
        ResourceValueUI.enabled = false;
        animator.SetBool("IsStart", false);
    }
}
