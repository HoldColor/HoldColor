using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveInteractAction : MonoBehaviour {
    GameObject PlayerController;
	// Use this for initialization
	void Start () {
        PlayerController = GameObject.Find("PlayerController");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InvokeRepeating("AddPlayerEnergy", 0, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke();
    }
    private void AddPlayerEnergy()
    {
        PlayerController.GetComponent<PlayerController>().Info.GetComponent<StateBar>().RestoreEnergy(10);
    }
}
