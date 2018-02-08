using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class HingeInteractAction : MonoBehaviour {
    private HingeController OwnController;
    private List<Collider2D> BodyCollisions;
    private InteractController interactController;
    private int _addHealthBySecond;
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
    public int AddHealthBySecond
    {
        get
        {
            return _addHealthBySecond;
        }
        set
        {
            _addHealthBySecond = value;
        }
    }
    // Use this for initialization
    void Start () {
        OwnController = gameObject.GetComponentInParent<HingeController>();
        BodyCollisions = new List<Collider2D>();
        _addHealthBySecond = HingeConfig._AddHealthBySecond;
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
            if (BodyCollisions.Count == 0)
            {
                InvokeRepeating("AddHealth", 0, 1);
            }
            BodyCollisions.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BodyCollisions.Remove(collision);
        if (BodyCollisions.Count == 0)
        {
            CancelInvoke();
        }
    }

    private void AddHealth()
    {
        foreach (Collider2D C in BodyCollisions)
        {
            ColliderController ctrl = C.gameObject.GetComponent<ColliderController>();
            ctrl.Info.GetComponent<StateBar>().RestoreHealth(_addHealthBySecond);
        }
    }
}
