using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class PlayerController : MonoBehaviour {
    public GameObject GameBody;
    public GameObject Path;
    public GameObject Interact;
    public GameObject Info;
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
        Interact.GetComponent<InteractController>().InteractRadius = 5f;
        StateBar statebar = Info.GetComponent<StateBar>();
        _health = 300;
        _energy = 100;
        statebar.TotalHealth = _health;
        statebar.TotalEnergy = _energy;
        statebar.CurrentEnergy = _energy;
        statebar.CurrentHealth = _health;
    }
}
