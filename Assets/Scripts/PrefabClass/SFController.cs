using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class SFController : MonoBehaviour {
    public enum SFType
    {
        Shield
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
            if (value != CampDefine.Campless)
            {
                InvokeRepeating("StartBuff", 0, 1.0f);
            } else
            {
                CancelInvoke();
            }
        }
    }
	// Use this for initialization
	void Awake () {
        _camp = CampDefine.Campless;
        GameBody.GetComponent<SpriteRenderer>().color = _camp;
        BodyCollider.GetComponent<ColliderController>().Camp = _camp;
	}
	
	public void StartBuff()
    {
        if (type == SFType.Shield)
        {
            ShieldBuff controller = gameObject.GetComponent<ShieldBuff>();
            controller.RestoreShield();
        }
    }
}
