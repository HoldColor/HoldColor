using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class ReserveController : MonoBehaviour {
    private bool isBuilding;
    public bool IsBuilding
    {
        get
        {
            return isBuilding;
        }
    }
    public GameObject Info;
    public GameObject BuildingBar;
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
        GameBody.GetComponent<SpriteRenderer>().color = CampDefine.Campless;
        Interact.GetComponent<InteractController>().InteractAreaColor = _camp;
        Interact.GetComponent<InteractController>().InteractCollider.GetComponent<ColliderController>().Camp = _camp;
        BodyCollider.GetComponent<ColliderController>().Camp = _camp;
        StateBar statebar = Info.GetComponent<StateBar>();
        _health = ReserveConfig._TotalHealth;
        _energy = ReserveConfig._TotalEnergy;
        statebar.TotalHealth = _health;
        statebar.TotalEnergy = _energy;
        statebar.CurrentEnergy = 0;
        statebar.CurrentHealth = 0;
        isBuilding = true;
        BuildingBar.GetComponent<BuildingBarController>().TotalHealth = _health;
        BuildingBar.GetComponent<BuildingBarController>().BuildTime = ReserveConfig._BuildingTime;

        GameObject.Find("Collector").GetComponent<Collector>().Reserve.Add(gameObject);
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

    private void Update()
    {
        if (Info.GetComponent<StateBar>().CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
