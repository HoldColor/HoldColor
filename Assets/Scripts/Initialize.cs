using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class Initialize : MonoBehaviour {
    private Color _camp;
    private GameObject Player;
    private GameObject Hinge;
    private GameObject OtherPlayer;
    private GameObject OtherHinge;
    private Collector Collector;
    public Color Camp
    {
        get
        {
            return _camp;
        }
    }
	// Use this for initialization
	private void Awake () {
        _camp = CampDefine.Green;
        Screen.SetResolution(GameConfig._ScreenWidth, GameConfig._ScreenHeight, GameConfig._FullScreen);
        Collector = GameObject.Find("Collector").GetComponent<Collector>();
        Player = Resources.Load<GameObject>("Prefabs/Player");
        Hinge = Resources.Load<GameObject>("Prefabs/Hinge");
        OtherPlayer = Resources.Load<GameObject>("Prefabs/OtherPlayer");
        OtherHinge = Resources.Load<GameObject>("Prefabs/OtherHinge");
    }

    public void initialize(MessageBox.InitializeMessage message)
    {
        _camp = GetOtherCamp(message.Camp);
        Debug.Log("Camp:" + _camp);
        MessageBox.Position position = JsonUtility.FromJson<MessageBox.Position>(message.PlayerPosition);
        GameObject player = Instantiate(Player, new Vector3(position.x, position.y, 0), new Quaternion());
        player.name = "Player";
        player.GetComponent<PlayerController>().id = message.PlayerID;
        player.GetComponentInChildren<StateBar>().id = message.PlayerID;
        Collector.Others.Add(new Collector.KeyValuePair
        {
            key = message.PlayerID,
            value = player
        });
        position = JsonUtility.FromJson<MessageBox.Position>(message.HingePosition);
        GameObject hinge = Instantiate(Hinge, new Vector3(position.x, position.y, 0), new Quaternion());
        hinge.name = "Hinge";
        hinge.GetComponent<HingeController>().id = message.HingeID;
        hinge.GetComponentInChildren<StateBar>().id = message.HingeID;
        Collector.Others.Add(new Collector.KeyValuePair
        {
            key = message.HingeID,
            value = hinge
        });
    }

    public void initializeOthers(MessageBox.OtherInitializeMessage message)
    {
        Color OtherCamp = GetOtherCamp(message.Camp);
        MessageBox.Position position = JsonUtility.FromJson<MessageBox.Position>(message.PlayerPosition);
        GameObject otherPlayer = Instantiate(OtherPlayer, new Vector3(position.x, position.y, 0), new Quaternion());
        otherPlayer.GetComponent<OtherObjectController>().id = message.PlayerID;
        otherPlayer.GetComponent<OtherObjectController>().type = OtherObjectController.Type.Player;
        otherPlayer.GetComponent<OtherObjectController>().SendMessage("Init", OtherCamp);
        position = JsonUtility.FromJson<MessageBox.Position>(message.HingePosition);
        GameObject otherHinge = Instantiate(OtherHinge, new Vector3(position.x, position.y, 0), new Quaternion());
        otherHinge.GetComponent<OtherObjectController>().id = message.HingeID;
        otherHinge.GetComponent<OtherObjectController>().type = OtherObjectController.Type.Hinge;
        otherHinge.GetComponent<OtherObjectController>().SendMessage("Init", OtherCamp);
    }

    public Color GetOtherCamp (string camp)
    {
        Color OtherCamp = new Color();
        switch (camp)
        {
            case "Orange":
                OtherCamp = CampDefine.Orange;
                break;
            case "Blue":
                OtherCamp = CampDefine.Blue;
                break;
            case "Green":
                OtherCamp = CampDefine.Green;
                break;
            case "Purple":
                OtherCamp = CampDefine.Purple;
                break;
        }
        return OtherCamp;
    }
}
