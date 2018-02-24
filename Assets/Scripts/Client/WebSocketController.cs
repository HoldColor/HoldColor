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
    private MessageBox.InitializeMessage InitializeMessage;
    private MessageBox.OtherInitializeMessage OtherInitializeMessage;
    private MessageBox.PlayerPosition PlayerPosition;
    private Collector Collector;
    private Initialize Initialize;
    // Use this for initialization
   void Awake () {
        MessageBase = new MessageBox.MessageBase();
        InitializeMessage = new MessageBox.InitializeMessage();
        OtherInitializeMessage = new MessageBox.OtherInitializeMessage();
        PlayerPosition = new MessageBox.PlayerPosition();
        Collector = GameObject.Find("Collector").GetComponent<Collector>();
        Initialize = GameObject.Find("InitializeController").GetComponent<Initialize>();
        Debug.Log("start connect");
        SocketConnect("ws://192.168.0.106:2222");
        Debug.Log("connect done");
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
                GameObject Player = new GameObject();
                foreach (Collector.KeyValuePair p in Collector.Others)
                {
                    Debug.Log(p.key);
                    if (p.key == PlayerPosition.id)
                    {
                        Player = p.value;
                        Debug.Log("get Player");
                    }
                }
                Player.transform.position = new Vector3(PlayerPosition.x, PlayerPosition.y, 0);
                Debug.Log("change player position");
                break;
            case "OtherInitializeMessage":
                JsonUtility.FromJsonOverwrite(MessageBase.Message, OtherInitializeMessage);
                Initialize.SendMessage("initializeOthers", OtherInitializeMessage);
                break;
        }
    }
}
