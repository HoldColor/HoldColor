using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateBar : MonoBehaviour {

    private Slider HealthBar;
    private Slider EnergyBar;
    private Text HealthInfo;
    private Text EnergyInfo;
    private int _CurrentHealth;
    private int _CurrentEnergy;
    private int _TotalHealth;
    private int _TotalEnergy;
    public int CurrentHealth
    {
        get
        {
            return _CurrentHealth;
        }
        set
        {
            _CurrentHealth = value;
            RefreshHealthInfo();
        }
    }
    public int CurrentEnergy
    {
        get
        {
            return _CurrentEnergy;
        }
        set
        {
            _CurrentEnergy = value;
            RefreshEnergyInfo();
        }
    }
    public int TotalHealth
    {
        get
        {
            return _TotalHealth;
        }
        set
        {
            _TotalHealth = value;
            RefreshHealthInfo();
        }
    }
    public int TotalEnergy
    {
        get
        {
            return _TotalEnergy;
        }
        set
        {
            _TotalEnergy = value;
            RefreshEnergyInfo();
        }
    }

    // Use this for initialization
    void Awake()
    {
        HealthBar = transform.Find("Health").GetComponent<Slider>();
        EnergyBar = transform.Find("Energy").GetComponent<Slider>();
        HealthInfo = transform.Find("HealthInfo").GetComponent<Text>();
        EnergyInfo = transform.Find("EnergyInfo").GetComponent<Text>();
        _TotalEnergy = 50;
        _TotalHealth = 200;
        _CurrentEnergy = _TotalEnergy;
        _CurrentHealth = _TotalHealth;
        HealthBar.value = ((float)_CurrentHealth / (float)_TotalHealth);
        HealthInfo.text = _CurrentHealth + "/" + _TotalHealth;
        EnergyInfo.text = _CurrentEnergy + "/" + _TotalEnergy;
        EnergyBar.value = ((float)_CurrentEnergy / (float)_TotalEnergy);
    }
    private void RefreshHealthInfo()
    {
        HealthBar.value = ((float)_CurrentHealth / (float)_TotalHealth);
        HealthInfo.text = _CurrentHealth + "/" + _TotalHealth;
    }
    private void RefreshEnergyInfo()
    {
        EnergyInfo.text = _CurrentEnergy + "/" + _TotalEnergy;
        EnergyBar.value = ((float)_CurrentEnergy / (float)_TotalEnergy);
    }
    public void RestoreHealth (int value)
    {
        if (_TotalHealth - _CurrentHealth >= value)
        {
            _CurrentHealth += value;
            RefreshHealthInfo();
        } else
        {
            _CurrentHealth = _TotalHealth;
            RefreshHealthInfo();
        }
    }
    public void ConsumeHealth (int value)
    {
        if (_CurrentHealth > value)
        {
            _CurrentHealth -= value;
            RefreshHealthInfo();
        } else
        {
            // DIE
        }
    }

    public void RestoreEnergy (int value)
    {
        if (_TotalEnergy - _CurrentEnergy >= value)
        {
            _CurrentEnergy += value;
            RefreshEnergyInfo();
        } else
        {
            _CurrentEnergy = _TotalEnergy;
            RefreshHealthInfo();
        }
    }
    public void ConsumeEnergy (int value)
    {
        if (_CurrentEnergy > value)
        {
            _CurrentEnergy -= value;
            RefreshEnergyInfo();
        } else
        {
            _CurrentEnergy = 0;
            RefreshEnergyInfo();
        }
    }
}
