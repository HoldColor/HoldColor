using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveInteractAction : MonoBehaviour {
    private ReserveController OwnController;
    private List<Collider2D> BodyCollisions;
	// Use this for initialization
	void Start () {
        OwnController = gameObject.GetComponentInParent<ReserveController>();
        BodyCollisions = new List<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.BodyCollider && OwnController.Camp == colliderController.Camp && collision.gameObject != OwnController.BodyCollider)
        {
            Debug.Log(collision.tag);
            if (BodyCollisions.Count == 0)
            {
                Debug.Log("startINvoke");
                InvokeRepeating("AddPlayerEnergy", 0, 2);
            }
            BodyCollisions.Add(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        BodyCollisions.Remove(collision);
        if (BodyCollisions.Count == 0)
        {
            Debug.Log("stopInvoke");
            CancelInvoke();
        }
    }
    private void AddPlayerEnergy()
    {
        foreach (Collider2D C in BodyCollisions)
        {
            ColliderController ctrl = C.gameObject.GetComponent<ColliderController>();
            ctrl.Info.GetComponent<StateBar>().RestoreEnergy(10);
        }
    }
}
