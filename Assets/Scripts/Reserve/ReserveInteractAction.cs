using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class ReserveInteractAction : MonoBehaviour {
    private ReserveController OwnController;
    private List<Collider2D> BodyCollisions;
    private int _addEnergyByCycle;
    private float _cycle;
    private InteractController interactController;
    private float _interactAreaRadius;
    public float InteractAreaRadius
    {
        get
        {
            return _interactAreaRadius;
        }
        set
        {
            _interactAreaRadius = value;
            interactController.InteractRadius = value;
        }
    }
    public int AddResourceByCycle
    {
        get
        {
            return _addEnergyByCycle;
        }
        set
        {
            _addEnergyByCycle = value;
        }
    }
    public float Cycle {
        get
        {
            return _cycle;
        }
        set
        {
            _cycle = value;
            if (IsInvoking())
            {
                CancelInvoke();
                InvokeRepeating("AddPlayerEnergy", 0, value);
            }
        }
    }
	// Use this for initialization
	void Awake () {
        OwnController = gameObject.GetComponentInParent<ReserveController>();
        BodyCollisions = new List<Collider2D>();
        _addEnergyByCycle = ReserveConfig._AddEnergyByCycle;
        _cycle = ReserveConfig._AddEnergyCycle;
        _interactAreaRadius = ReserveConfig._InteractAreaRadius;
        interactController = gameObject.GetComponentInParent<InteractController>();
        interactController.InteractRadius = _interactAreaRadius;
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
                InvokeRepeating("AddPlayerEnergy", 0, _cycle);
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
            ctrl.Info.GetComponent<StateBar>().RestoreEnergy(_addEnergyByCycle);
        }
    }
}
