using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class PlayerMoveController : MonoBehaviour {
    private enum PlayerStatus
    {
        picked,
        unpicked,
        pickedANDmoving,
        unpickedANDmoving
    }
    private PlayerStatus status;
    private GameObject canvas;
    private Vector3 des;
    private GameObject ppc;
    private GameObject InteractLine;
	// Use this for initialization
	void Start () {
        status = PlayerStatus.unpicked;
        des = new Vector3(0, 0, 0);
        canvas = GameObject.Find("PlayerController").GetComponent<PlayerController>().Info;
        this.gameObject.AddComponent<BoxCollider>();
        ppc = GameObject.Find("PlayerController").GetComponent<PlayerController>().Path;
        InteractLine = GameObject.Find("PlayerController").GetComponent<PlayerController>().Interact.GetComponent<InteractController>().InteractArea;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (this.status == PlayerStatus.unpickedANDmoving)
                    this.status = PlayerStatus.pickedANDmoving;
                else this.status = PlayerStatus.picked;
            } else
            {
                if (this.status == PlayerStatus.pickedANDmoving)
                    this.status = PlayerStatus.unpickedANDmoving;
                else this.status = PlayerStatus.unpicked;
            }
        }
        if (Input.GetMouseButton(1) && this.status == PlayerStatus.picked
            || Input.GetMouseButton(1) && this.status == PlayerStatus.pickedANDmoving)
        {
            this.status = PlayerStatus.pickedANDmoving;
            des = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
		switch (status) {
            case PlayerStatus.unpicked:
                canvas.SetActive(true);
                ppc.SetActive(false);
                InteractLine.SetActive(false);
                break;
            case PlayerStatus.picked:
                canvas.SetActive(true);
                ppc.SetActive(false);
                InteractLine.SetActive(true);
                break;
            case PlayerStatus.pickedANDmoving:
                canvas.SetActive(true);
                ppc.SetActive(true);
                InteractLine.SetActive(true);
                PlayerMove();
                break;
            case PlayerStatus.unpickedANDmoving:
                canvas.SetActive(true);
                ppc.SetActive(false);
                InteractLine.SetActive(false);
                PlayerMove();
                break;
        }
	}

    void PlayerMove ()
    {
        if (ppc.activeSelf == true)
        {
            Vector3[] path = new Vector3[2];
            path[0] = this.transform.position;
            path[0].z = 0;
            path[1] = des;
            path[1].z = 0;
            ppc.SendMessage("draw", path);
        }
        Vector3 cur, dir;
        if (this.status == PlayerStatus.pickedANDmoving || this.status == PlayerStatus.unpickedANDmoving)
        {
            cur = this.transform.position;
            des.z = 0; cur.z = 0;
            dir = des - cur;
            dir.Normalize();
            this.transform.position += dir * PlayerConfig._MoveSpeed * Time.deltaTime;
        }
        if (Vector3.Distance(this.transform.position, des) <= 0.05f)
        {
            if (this.status == PlayerStatus.pickedANDmoving)
                this.status = PlayerStatus.picked;
            if (this.status == PlayerStatus.unpickedANDmoving)
                this.status = PlayerStatus.unpicked;
        }
    }
}
