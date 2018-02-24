using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class PlayerController : MonoBehaviour {
    public string id;
    private WebSocketController WS;
    public GameObject GameBody;
    public GameObject Path;
    public GameObject Interact;
    public GameObject Info;
    public GameObject BodyCollider;
    private int _health;
    private int _energy;
    private Color _camp;
    private float _interactRadius;
    private MessageBox.PlayerPosition PP;
    private MessageBox.MessageBase MB;
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
        GameObject.Find("Collector").GetComponent<Collector>().Player = gameObject;
        Vector3 CP = new Vector3();
        CP = transform.position;
        CP.z = -10;
        Camera.main.transform.position = CP;
        WS = GameObject.Find("WebSocketController").GetComponent<WebSocketController>();
        PP = new MessageBox.PlayerPosition();
        MB = new MessageBox.MessageBase();
    }

    private void Update()
    {
        if (Info.GetComponent<StateBar>().CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        PP.id = id;
        PP.x = transform.position.x;
        PP.y = transform.position.y;
        MB.Type = "PlayerPosition";
        MB.Message = JsonUtility.ToJson(PP);
        Debug.Log(MB.Message);
        WS.Send(JsonUtility.ToJson(MB));
    }
}
