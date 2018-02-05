using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductingResourceController : MonoBehaviour {

    private Animator animator;
    private Text ResourceValueUI;
    private int _resourceBySecond;
    private AnimationClip ProducingClip;
    public int ResourceBySecond
    {
        get
        {
            return _resourceBySecond;
        }
        set
        {
            _resourceBySecond = value;
            ResourceValueUI.text = "Resource +" + _resourceBySecond;
        }
    }

    // Use this for initialization
    void Awake() {
        ResourceValueUI = gameObject.GetComponent<Text>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Start", true);
        _resourceBySecond = 2;
        ResourceValueUI.text = "Resource +" + _resourceBySecond;

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
        ResourceController.instance.PlayerResources += _resourceBySecond;
    }
}
