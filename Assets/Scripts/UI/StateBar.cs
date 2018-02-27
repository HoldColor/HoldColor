using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoldColor.Config;

public class StateBar : MonoBehaviour {
    private WebSocketController WS;
    public string id;
    private bool _isShield;
    private Slider HealthBar;
    private Slider EnergyBar;
    private Slider Shield;
    private Text HealthInfo;
    private Text EnergyInfo;
    private Text ShieldInfo;
    private float _CurrentHealth;
    private float _CurrentEnergy;
    private float _TotalHealth;
    private float _TotalEnergy;
    private float _TotalShield;
    private float _CurrentShield;
    public bool IsShield
    {
        get
        {
            return _isShield;
        }
        set
        {
            _isShield = value;
            if (value)
            {
                Shield.gameObject.SetActive(true);
                ShieldInfo.gameObject.SetActive(true);
            } else
            {
                Shield.gameObject.SetActive(false);
                ShieldInfo.gameObject.SetActive(false);
            }
        }
    }
    public float CurrentShield
    {
        get
        {
            return _CurrentShield;
        }
        set
        {
            _CurrentShield = value;
            RefreshShieldInfo();
        }
    }
    public float TotalShield
    {
        get
        {
            return _TotalShield;
        }
        set
        {
            _TotalShield = value;
            RefreshShieldInfo();
        }
    }
    public float CurrentHealth
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
    public float CurrentEnergy
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
    public float TotalHealth
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
    public float TotalEnergy
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
        WS = GameObject.Find("WebSocketController").GetComponent<WebSocketController>();
        HealthBar = transform.Find("Health").GetComponent<Slider>();
        EnergyBar = transform.Find("Energy").GetComponent<Slider>();
        Shield = transform.Find("Shield").GetComponent<Slider>();
        HealthInfo = transform.Find("HealthInfo").GetComponent<Text>();
        EnergyInfo = transform.Find("EnergyInfo").GetComponent<Text>();
        ShieldInfo = transform.Find("ShieldInfo").GetComponent<Text>();
        _isShield = false;
        Shield.gameObject.SetActive(false);
        ShieldInfo.gameObject.SetActive(false);
        _TotalEnergy = 50;
        _TotalHealth = 200;
        _TotalShield = ShieldSF._TotalShield;
        _CurrentEnergy = _TotalEnergy;
        _CurrentHealth = _TotalHealth;
        _CurrentShield = 0;
        Shield.value = 0;
        HealthBar.value = ((float)_CurrentHealth / (float)_TotalHealth);
        HealthInfo.text = _CurrentHealth + "/" + _TotalHealth;
        EnergyInfo.text = _CurrentEnergy + "/" + _TotalEnergy;
        EnergyBar.value = ((float)_CurrentEnergy / (float)_TotalEnergy);
        ShieldInfo.text = _CurrentShield.ToString();
    }
    private void RefreshHealthInfo()
    {
        HealthBar.value = ((float)_CurrentHealth / (float)_TotalHealth);
        HealthInfo.text = (int)_CurrentHealth + "/" + (int)_TotalHealth;
    }
    private void RefreshEnergyInfo()
    {
        EnergyInfo.text = (int)_CurrentEnergy + "/" + (int)_TotalEnergy;
        EnergyBar.value = ((float)_CurrentEnergy / (float)_TotalEnergy);
    }
    private void RefreshShieldInfo()
    {
        Shield.value = ((float)_CurrentShield / (float)_TotalShield);
        ShieldInfo.text = _CurrentShield.ToString();
    }
    public void RestoreHealth (float value)
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
        CreateMessageAndSend();
    }
    public void ConsumeHealth (float value)
    {
        if (IsShield)
        {
            if (_CurrentShield > value)
            {
                _CurrentShield -= value;
                RefreshShieldInfo();
            }
            else
            {
                if (_CurrentHealth >= (value - _CurrentShield))
                {
                    _CurrentHealth -= (value - _CurrentShield);
                    RefreshHealthInfo();
                }
                else
                {
                    _CurrentHealth = 0;
                    RefreshHealthInfo();
                }
                _CurrentShield = 0;
                RefreshShieldInfo();
                Shield.gameObject.SetActive(false);
                ShieldInfo.gameObject.SetActive(false);
                IsShield = false;
            }
        } else
        {
            if (_CurrentHealth >= value)
            {
                _CurrentHealth -= value;
                RefreshHealthInfo();
            }
            else
            {
                _CurrentHealth = 0;
                RefreshHealthInfo();
            }
        }
        CreateMessageAndSend();
    }

    public void RestoreEnergy (float value)
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
        CreateMessageAndSend();
    }
    public void ConsumeEnergy (float value)
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
        CreateMessageAndSend();
    }
    public void RestoreShield(float value)
    {
        if (_TotalShield - _CurrentShield >= value)
        {
            _CurrentShield += value;
            RefreshShieldInfo();
        }
        else
        {
            _CurrentShield = _TotalShield;
            RefreshShieldInfo();
        }
        CreateMessageAndSend();
    }

    private void CreateMessageAndSend()
    {
        MessageBox.MessageBase MB = new MessageBox.MessageBase();
        MB.Type = "ChangeStateBar";
        MessageBox.ChangeStateBar CSB = new MessageBox.ChangeStateBar
        {
            id = id,
            Health = _CurrentHealth,
            Energy = _CurrentEnergy,
            Shield = _CurrentShield
        };
        MB.Message = JsonUtility.ToJson(CSB);
        WS.Send(JsonUtility.ToJson(MB));
    }

    public void ChangeInfoByMessage(MessageBox.ChangeStateBar CSB)
    {
        CurrentEnergy = CSB.Energy;
        CurrentHealth = CSB.Health;
        CurrentShield = CSB.Shield;
    }
}
