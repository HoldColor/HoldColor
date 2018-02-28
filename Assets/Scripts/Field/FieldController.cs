using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class FieldController : MonoBehaviour {
    public string id;
    private bool isBuilding;
    public bool IsBuilding
    {
        get
        {
            return isBuilding;
        }
    }
    public GameObject Info;
    public GameObject GameBody;
    private Color _camp;
    private int _health;
    private int _energy;
    public GameObject FieldArea;
    public GameObject BodyCollider;
    public GameObject BuildingBar;
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
        // GameBody.GetComponent<SpriteRenderer>().color = _camp;
        GameBody.GetComponent<SpriteRenderer>().color = CampDefine.Campless;
        FieldArea.GetComponent<FieldAreaController>().FieldAreaCollider.GetComponent<ColliderController>().Camp = _camp;
        BodyCollider.GetComponent<ColliderController>().Camp = _camp;
        StateBar statebar = Info.GetComponent<StateBar>();
        _health = Field._TotalHealth;
        _energy = Field._TotalEnergy;
        statebar.TotalHealth = _health;
        statebar.TotalEnergy = _energy;
        statebar.CurrentEnergy = 0;
        statebar.CurrentHealth = 0;
        isBuilding = true;
        BuildingBar.GetComponent<BuildingBarController>().TotalHealth = _health;
        BuildingBar.GetComponent<BuildingBarController>().BuildTime = Field._BuildingTime;
        GameObject.Find("Collector").GetComponent<Collector>().Field.Add(gameObject);
    }

    private void Update()
    {
        if (Info.GetComponent<StateBar>().CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void HasBuilt(bool isture)
    {
        if (isture)
        {
            Destroy(BuildingBar);
            GameBody.GetComponent<SpriteRenderer>().color = _camp;
            isBuilding = false;
        }
    }
}
