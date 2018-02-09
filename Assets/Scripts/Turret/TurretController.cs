using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class TurretController : MonoBehaviour {
    public GameObject GameBody;
    public GameObject Interact;
    public GameObject Info;
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
        // _camp = GameObject.Find("InitializeController").GetComponent<Initialize>().Camp;
        _camp = CampDefine.Purple;
        GameBody.GetComponent<SpriteRenderer>().color = _camp;
        Interact.GetComponent<InteractController>().InteractAreaColor = _camp;
        Interact.GetComponent<InteractController>().InteractCollider.GetComponent<ColliderController>().Camp = _camp;
        BodyCollider.GetComponent<ColliderController>().Camp = _camp;
        StateBar statebar = Info.GetComponent<StateBar>();
        _health = TurretConfig._TotalHealth;
        _energy = TurretConfig._TotalEnergy;
        statebar.TotalHealth = _health;
        statebar.TotalEnergy = _energy;
        statebar.CurrentEnergy = _energy;
        statebar.CurrentHealth = _health;
    }
}
