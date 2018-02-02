using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.mousePosition.y < Screen.height / 10 && Input.mousePosition.y >= 0)
        {
            Camera.main.transform.position += new Vector3(0, -1, 0) * CameraConfig.MoveSpeed;
        }
        if (Input.mousePosition.y > Screen.height * 9 / 10 && Input.mousePosition.y <= Screen.height)
        {
            Camera.main.transform.position += new Vector3(0, 1, 0) * CameraConfig.MoveSpeed;
        }
        if (Input.mousePosition.x < Screen.width / 10 && Input.mousePosition.x >= 0) {
            Camera.main.transform.position += new Vector3(-1, 0, 0) * CameraConfig.MoveSpeed;
        }
        if (Input.mousePosition.x > Screen.width * 9 / 10 && Input.mousePosition.x <= Screen.width)
        {
            Camera.main.transform.position += new Vector3(1, 0, 0) * CameraConfig.MoveSpeed;
        }
	}
}
