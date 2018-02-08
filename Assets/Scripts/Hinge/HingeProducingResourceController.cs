using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoldColor.Config;

public class HingeProducingResourceController : MonoBehaviour {

    private Animator animator;
    private Text ResourceValueUI;
    private int _resourceByCycle;
    private AnimationClip ProducingClip;
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
        animator.SetBool("Start", true);
        _resourceByCycle = ResourceConfig._AddResourceByCycle;
        _cycle = ResourceConfig._AddResourceCycle;
        ResourceValueUI.text = "Resource +" + _resourceByCycle;
        float ProductingSpeed = _cycle;
        animator.SetFloat("ProductingSpeed", ProductingSpeed);
        for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            if (animator.runtimeAnimatorController.animationClips[i].name == "HingeProducing")
            {
                ProducingClip = animator.runtimeAnimatorController.animationClips[i];
            }
        }
        AnimationEvent evt = new AnimationEvent();
        evt.time = 0;
        evt.functionName = "AddResource";
        ProducingClip.AddEvent(evt);
    }

    void AddResource()
    {
        ResourceController.instance.PlayerResources += _resourceByCycle;
    }
}
