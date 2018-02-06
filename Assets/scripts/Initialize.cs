using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class Initialize : MonoBehaviour {
    private Color _camp;
    public Color Camp
    {
        get
        {
            return _camp;
        }
    }
	// Use this for initialization
	private void Awake () {
        _camp = CampDefine.Orange;
        Debug.Log("Init");
        Screen.SetResolution(GameConfig._ScreenWidth, GameConfig._ScreenHeight, GameConfig._FullScreen);
	}
}
