using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class FieldController : MonoBehaviour {
    public GameObject Info;
    public GameObject GameBody;
    private Color _camp;
    private int _health;
    private int _energy;
    public GameObject FieldArea;
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
        FieldArea.GetComponent<FieldAreaController>().FieldAreaCollider.GetComponent<ColliderController>().Camp = _camp;
        BodyCollider.GetComponent<ColliderController>().Camp = _camp;
        StateBar statebar = Info.GetComponent<StateBar>();
        _health = Field._TotalHealth;
        _energy = Field._TotalEnergy;
        statebar.TotalHealth = _health;
        statebar.TotalEnergy = _energy;
        statebar.CurrentEnergy = _energy;
        statebar.CurrentHealth = _health;

        GameObject.Find("Collector").GetComponent<Collector>().Field.Add(gameObject);
    }

    private void Update()
    {
        if (Info.GetComponent<StateBar>().CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
