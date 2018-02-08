using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class HingeController : MonoBehaviour {

	public GameObject ResourceUI;
    public GameObject GameBody;
    public GameObject Info;
    public GameObject Interact;
    public GameObject BodyCollider;
    private int _health;
    private int _energy;
    private Color _camp;
    public Color Camp
    {
        get
        {
            return _camp;
        }
    }
    private void Start()
    {
        _camp = GameObject.Find("InitializeController").GetComponent<Initialize>().Camp;
        GameBody.GetComponent<SpriteRenderer>().color = _camp;
        Interact.GetComponent<InteractController>().InteractAreaColor = _camp;
        Interact.GetComponent<InteractController>().InteractCollider.GetComponent<ColliderController>().Camp = _camp;
        BodyCollider.GetComponent<ColliderController>().Camp = _camp;
        StateBar statebar = Info.GetComponent<StateBar>();
        _health = HingeConfig._TotalHealth;
        _energy = HingeConfig._TotalEnergy;
        statebar.TotalHealth = _health;
        statebar.TotalEnergy = _energy;
        statebar.CurrentEnergy = _energy;
        statebar.CurrentHealth = _health;
    }
}
