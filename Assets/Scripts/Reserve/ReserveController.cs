using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class ReserveController : MonoBehaviour {

    public GameObject Info;
    public GameObject GameBody;
    private Color _camp;
    private int _health;
    private int _energy;
    public GameObject Interact;
    public GameObject BodyCollider;
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
        _health = ReserveConfig._TotalHealth;
        _energy = ReserveConfig._TotalEnergy;
        statebar.TotalHealth = _health;
        statebar.TotalEnergy = _energy;
        statebar.CurrentEnergy = _energy;
        statebar.CurrentHealth = _health;
    }

    private void Update()
    {
        if (Info.GetComponent<StateBar>().CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
