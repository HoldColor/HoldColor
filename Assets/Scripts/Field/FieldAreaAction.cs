using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class FieldAreaAction : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        FieldController FC = GetComponentInParent<FieldController>();
        if ((colliderController.Type == ColliderController.ColliderType.FieldBuildCollider 
            || colliderController.Type == ColliderController.ColliderType.TurretBuildCollider
            || colliderController.Type == ColliderController.ColliderType.ReserveBuildCollider) 
            && !FC.IsBuilding)
        {
            CanBuild(false, colliderController, collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        FieldController FC = gameObject.GetComponentInParent<FieldController>();
        if ((colliderController.Type == ColliderController.ColliderType.FieldBuildCollider
            || colliderController.Type == ColliderController.ColliderType.TurretBuildCollider
            || colliderController.Type == ColliderController.ColliderType.ReserveBuildCollider)
            && !FC.IsBuilding)
        {
            CanBuild(true, colliderController, collision);
        }
    }

    private void CanBuild(bool flag, ColliderController colliderController, Collider2D collision)
    {
        switch (colliderController.Type)
        {
            case ColliderController.ColliderType.TurretBuildCollider:
                collision.gameObject.GetComponent<TurretBuildTipController>().IsBuildAbled = flag;
                break;
            case ColliderController.ColliderType.FieldBuildCollider:
                collision.gameObject.GetComponent<FieldBuildTipController>().IsBuildAbled = flag;
                break;
            case ColliderController.ColliderType.ReserveBuildCollider:
                collision.gameObject.GetComponent<ReserveBuildTipController>().IsBuildAbled = flag;
                break;
        }
    }
}
