using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class TurretBuildTipController : MonoBehaviour {
    private float Radius;
	// Use this for initialization
	void Start () {
        Radius = TurretConfig._InteractAreaRadius;
        gameObject.GetComponentInChildren<BuildAreaTip>().Radius = Radius;
        gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingDiasbled;
	}
    private void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
        gameObject.transform.position = target;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.FieldCollider)
        {
            gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingDiasbled;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.FieldCollider)
        {
            gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingAbled;
        }
    }
}
