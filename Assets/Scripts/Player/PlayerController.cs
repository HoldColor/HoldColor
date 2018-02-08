using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class PlayerController : MonoBehaviour {
    public GameObject GameBody;
    public GameObject Path;
    public GameObject Interact;
    public GameObject Info;
    public GameObject BodyCollider;
    private int _health;
    private int _energy;
    private Color _camp;
    private float _interactRadius;
    public Color Camp
    {
        get {
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
        _health = PlayerConfig._TotalHealth;
        _energy = PlayerConfig._TotalEnergy;
        statebar.TotalHealth = _health;
        statebar.TotalEnergy = _energy;
        statebar.CurrentEnergy = 10;
        statebar.CurrentHealth = 100;
    }
}
