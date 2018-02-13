using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class SFController : MonoBehaviour {
    public enum SFType
    {
        Shield,
        Resource,
        Attack
    }
    public GameObject GameBody;
    public GameObject Info;
    public GameObject BodyCollider;
    public GameObject Interact;
    public SFType type;
    private Color _camp;
    public Color Camp
    {
        get
        {
            return _camp;
        }
        set
        {
            _camp = value;
            GameBody.GetComponent<SpriteRenderer>().color = value;
            BodyCollider.GetComponent<ColliderController>().Camp = value;
            switch (type)
            {
                case SFType.Shield:
                    if (value != CampDefine.Campless)
                    {
                        InvokeRepeating("StartShieldBuff", 0, 1.0f);
                    }
                    else
                    {
                        CancelInvoke();
                    }
                    break;
                case SFType.Resource:
                    if (value != CampDefine.Campless)
                    {
                        StartResourceBuff();
                    }
                    else
                    {
                        CloseResourceBuff();
                    }
                    break;
                case SFType.Attack:
                    if (value != CampDefine.Campless)
                    {
                        StartAttackBuff();
                    }
                    else
                    {
                        StopAttackBuff();
                    }
                    break;
            }
        }
    }
	// Use this for initialization
	void Awake () {
        _camp = CampDefine.Campless;
        GameBody.GetComponent<SpriteRenderer>().color = _camp;
        BodyCollider.GetComponent<ColliderController>().Camp = _camp;
        Interact.GetComponent<InteractController>().InteractArea.SetActive(false);
	}
	
	public void StartShieldBuff()
    {
        ShieldBuff controller = gameObject.GetComponent<ShieldBuff>();
        controller.RestoreShield();
    }

    public void StartResourceBuff()
    {
        ResourceBuff controller = gameObject.GetComponent<ResourceBuff>();
        controller.AddResource();
    }

    public void CloseResourceBuff()
    {
        ResourceBuff controller = gameObject.GetComponent<ResourceBuff>();
        controller.CloseBuff();
    }

    public void StartAttackBuff()
    {
        AttackBuff controller = gameObject.GetComponent<AttackBuff>();
        controller.StartAttackBuff();
    }

    public void StopAttackBuff()
    {
        AttackBuff controller = gameObject.GetComponent<AttackBuff>();
        controller.StopAttackBuff();
    }
}
