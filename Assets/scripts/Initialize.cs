using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class Initialize : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Screen.SetResolution(GameConfig.ScreenWidth, GameConfig.ScreenHeight, GameConfig.FullScreen);
	}
}
