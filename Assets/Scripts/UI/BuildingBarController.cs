using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoldColor.Config;

public class BuildingBarController : MonoBehaviour {
    public enum BuildingType
    {
        Turret,
        Field
    }
    public float BuildTime
    {
        set
        {
            _time = value;
            InvokeRepeating("StartBuilding", 0, _cycle);
        }
    }
    public float TotalHealth
    {
        set
        {
            _totalHealth = value;
        }
    }
    public BuildingType type;
    public GameObject Info;
    private float _time;
    private float _totalHealth;
    private float _totalValue;
    private float _currentValue;
    private float _cycle;
    private Slider Bar;
    private Image Fill;
    private MonoBehaviour OwnController;
    // Use this for initialization
    private void Awake()
    {
        Bar = gameObject.transform.Find("bar").GetComponent<Slider>();
        _totalValue = 100;
        _currentValue = 100;
        Bar.value = 1f;
        _cycle = 0.1f;
        Fill = gameObject.transform.Find("bar/Fill Area/Fill").GetComponent<Image>();
        Fill.color = GameObject.Find("InitializeController").GetComponent<Initialize>().Camp;
        switch (type)
        {
            case BuildingType.Turret:
                OwnController = GetComponentInParent<TurretController>();
                break;
            case BuildingType.Field:
                OwnController = GetComponentInParent<FieldController>();
                break;
        }
    }

    private void StartBuilding()
    {
        float ProcessByCycle = _totalValue / _time * _cycle;
        float HealthByCycle = _totalHealth / _time * _cycle;
        Processing(ProcessByCycle);
        Info.GetComponent<StateBar>().RestoreHealth(HealthByCycle);
        if (_currentValue <= 0)
        {
            Info.GetComponent<StateBar>().CurrentHealth = _totalHealth;
            OwnController.SendMessage("HasBuilt", true);
            CancelInvoke();
        }
    }
    
    private void Processing(float ByCycle)
    {
        _currentValue -= ByCycle;
        Bar.value = ((float)_currentValue / (float)_totalValue);
    }
}
