using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class CameraMove : MonoBehaviour {

    private bool isFollowing;

	// Use this for initialization
	void Start () {
        isFollowing = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFollowing) isFollowing = false;
            else isFollowing = true;
        }
        if (isFollowing)
        {
            Vector3 player = GameObject.Find("Player").GetComponent<PlayerController>().GameBody.transform.position;
            player.z = -10;
            transform.position = player;
        } else {
            if (Input.mousePosition.y < Screen.height / 10 && Input.mousePosition.y >= 0)
            {
                Camera.main.transform.position += new Vector3(0, -1, 0) * CameraConfig._MoveSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.y > Screen.height * 9 / 10 && Input.mousePosition.y <= Screen.height)
            {
                Camera.main.transform.position += new Vector3(0, 1, 0) * CameraConfig._MoveSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x < Screen.width / 10 && Input.mousePosition.x >= 0)
            {
                Camera.main.transform.position += new Vector3(-1, 0, 0) * CameraConfig._MoveSpeed * Time.deltaTime;
            }
            if (Input.mousePosition.x > Screen.width * 9 / 10 && Input.mousePosition.x <= Screen.width)
            {
                Camera.main.transform.position += new Vector3(1, 0, 0) * CameraConfig._MoveSpeed * Time.deltaTime;
            }
        }
	}
}
