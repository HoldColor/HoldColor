using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class WebSocketController : MonoBehaviour {
    [DllImport("__Internal")]
    private static extern void SocketConnect(string url);
    [DllImport("__Internal")]
    private static extern void SocketSendMessage(string msg);
    [DllImport("__Internal")]
    private static extern void SocketClose();

    private MessageBox.MessageBase MessageBase;
    private MessageBox.Position Position;
    private MessageBox.InitializeMessage InitializeMessage;
    private MessageBox.OtherInitializeMessage OtherInitializeMessage;
    private MessageBox.PlayerPosition PlayerPosition;
    private Collector Collector;
    private Initialize Initialize;
    // Use this for initialization
   void Awake () {
        MessageBase = new MessageBox.MessageBase();
        Position = new MessageBox.Position();
        InitializeMessage = new MessageBox.InitializeMessage();
        OtherInitializeMessage = new MessageBox.OtherInitializeMessage();
        PlayerPosition = new MessageBox.PlayerPosition();
        Collector = GameObject.Find("Collector").GetComponent<Collector>();
        Initialize = GameObject.Find("InitializeController").GetComponent<Initialize>();
        SocketConnect("ws://127.0.0.1:2222");
    }

    public void Send(string msg)
    {
        SocketSendMessage(msg);
    }

    void Open()
    {
        Debug.Log("connected!");
    }

    void Close()
    {
        Debug.Log("closed!");
    }

    void OnMessage(string data)
    {
        Debug.Log("data:" + data);
        JsonUtility.FromJsonOverwrite(data, MessageBase);
        switch (MessageBase.Type)
        {
            case "InitializeMessage":
                JsonUtility.FromJsonOverwrite(MessageBase.Message, InitializeMessage);
                Initialize.SendMessage("initialize", InitializeMessage);
                break;
            case "PlayerPosition":
                JsonUtility.FromJsonOverwrite(MessageBase.Message, PlayerPosition);
                Debug.Log("PlayerPosition:" + PlayerPosition.id);
                Debug.Log("PlayerPosition:" + PlayerPosition.x);
                Debug.Log("PlayerPosition:" + PlayerPosition.y);
                GameObject Player = new GameObject();
                foreach (Collector.KeyValuePair p in Collector.Others)
                {
                    if (p.key == PlayerPosition.id)
                    {
                        Player = p.value;
                    }
                }
                Player.transform.position = new Vector3(Position.x, Position.y, 0);
                break;
            case "OtherInitializeMessage":
                JsonUtility.FromJsonOverwrite(MessageBase.Message, OtherInitializeMessage);
                Initialize.SendMessage("initializeOthers", OtherInitializeMessage);
                break;
        }
    }
}
