using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class SFInteractAction : MonoBehaviour {
    private SFController OwnController;
    public List<Collider2D> BodyCollisions;
    private InteractController interactController;
    private float _interactAreaRadius;
    private Color TargetCamp;
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
    // Use this for initialization
    void Start () {
        OwnController = gameObject.GetComponentInParent<SFController>();
        BodyCollisions = new List<Collider2D>();
        _interactAreaRadius = SFConfig._InteractAreaRadius;
        interactController = gameObject.GetComponentInParent<InteractController>();
        interactController.InteractRadius = _interactAreaRadius;
    }

    private void Update()
    {
        if (BodyCollisions.Count == 0)
        {
            CancelInvoke();
        }
        else
        {
            TargetCamp = BodyCollisions[0].gameObject.GetComponent<ColliderController>().Camp;
            foreach (Collider2D c in BodyCollisions)
            {
                if (c.gameObject.GetComponent<ColliderController>().Camp != TargetCamp)
                {
                    CancelInvoke();
                }
                else if (!IsInvoking() && OwnController.Info.GetComponent<OccupyBarController>().NowCamp != TargetCamp) InvokeRepeating("Occupy", 0, 0.1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.BodyCollider && collision.gameObject != OwnController.BodyCollider)
        {
            BodyCollisions.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (BodyCollisions.Contains(collision))
        {
            BodyCollisions.Remove(collision);
            if (BodyCollisions.Count == 0)
            {
                CancelInvoke();
            }
        }
    }

    private void Occupy()
    {
        if (OwnController.Info.GetComponent<OccupyBarController>().Occupy(SFConfig._OccupyPointBySecond * BodyCollisions.Count / 10, TargetCamp))
        {
            CancelInvoke();
        }
    }

}
