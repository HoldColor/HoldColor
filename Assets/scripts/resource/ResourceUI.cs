using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {
    private ResourceController Resources;
    private Text text;
	// Use this for initialization
	void Awake () {
		Resources = ResourceController.instance;
        text = gameObject.GetComponent<Text>();
        Resources.PlayerResources = 200;
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "资源:" + Resources.PlayerResources;
	}
}
