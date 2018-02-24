using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class OtherObjectController : MonoBehaviour {
    public Color Camp;
    public string id;
    private Collector Collector;
    private void Awake () {
        Collector = GameObject.Find("Collector").GetComponent<Collector>();
    }

    public void Init(Color camp)
    {
        Debug.Log(gameObject.name + id);
        Camp = camp;
        gameObject.GetComponent<SpriteRenderer>().color = Camp;
        gameObject.GetComponent<ColliderController>().Camp = Camp;
        Collector.KeyValuePair Pair = new Collector.KeyValuePair
        {
            key = id,
            value = gameObject
        };
        Collector.Others.Add(Pair);
    }
}
