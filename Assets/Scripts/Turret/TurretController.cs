using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class TurretController : MonoBehaviour {
    private bool isBuilding;
    public bool IsBuilding
    {
        get
        {
            return isBuilding;
        }
    }
    public GameObject GameBody;
    public GameObject Interact;
    public GameObject Info;
    public GameObject BodyCollider;
    public GameObject BuildingBar;
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
        GameBody.GetComponent<SpriteRenderer>().color = CampDefine.Campless;
        Interact.GetComponent<InteractController>().InteractCollider.GetComponent<ColliderController>().Camp = _camp;
        BodyCollider.GetComponent<ColliderController>().Camp = _camp;
        StateBar statebar = Info.GetComponent<StateBar>();  
        _health = TurretConfig._TotalHealth;
        _energy = TurretConfig._TotalEnergy;
        statebar.TotalHealth = _health;
        statebar.TotalEnergy = _energy;
        statebar.CurrentEnergy = 0;
        statebar.CurrentHealth = 0;
        isBuilding = true;
        BuildingBar.GetComponent<BuildingBarController>().TotalHealth = _health;
        BuildingBar.GetComponent<BuildingBarController>().BuildTime = TurretConfig._BuildingTime;
        GameObject.Find("Collector").GetComponent<Collector>().Turret.Add(gameObject);
    }

    public void HasBuilt(bool isture)
    {
        if (isture)
        {
            Destroy(BuildingBar);
            GameBody.GetComponent<SpriteRenderer>().color = _camp;
            Interact.GetComponent<InteractController>().InteractAreaColor = _camp;
            isBuilding = false;
        }
    }
}
