using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveInteractAction : MonoBehaviour {
    private GameObject PlayerController;
    private ReserveController OwnController;
    private Collider2D PlayerBodyCollision;
	// Use this for initialization
	void Start () {
        PlayerController = GameObject.Find("PlayerController");
        OwnController = GameObject.Find("ReserveController").GetComponent<ReserveController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (collision.gameObject.tag == "Player" && colliderController.Type == ColliderController.ColliderType.BodyCollider && OwnController.Camp == colliderController.Camp)
        {
            PlayerBodyCollision = collision;
            InvokeRepeating("AddPlayerEnergy", 0, 2);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == PlayerBodyCollision)
        {
            CancelInvoke();
        }
    }
    private void AddPlayerEnergy()
    {
        PlayerController.GetComponent<PlayerController>().Info.GetComponent<StateBar>().RestoreEnergy(10);
    }
}
