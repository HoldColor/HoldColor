using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractAction : MonoBehaviour {
    private GameObject Bullet;
    private Collider2D Target;
    private PlayerController OwnController;
    // Use this for initialization
    void Awake()
    {
        Bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        OwnController = gameObject.GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.BodyCollider && colliderController.Camp != OwnController.Camp)
        {
            Target = collision;
            InvokeRepeating("Shoot", 0, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == Target)
        {
            CancelInvoke();
        }
    }

    private void Shoot()
    {
        if (OwnController.Info.GetComponent<StateBar>().CurrentEnergy >= 10)
        {
            GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
            OwnController.Info.GetComponent<StateBar>().ConsumeEnergy(10);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            bulletController.target = Target.GetComponent<ColliderController>().GameBody;
            bulletController.targetCollider = Target;
            bulletController.isShoot = true;
            bulletController.Camp = OwnController.Camp;
        }
    }
}
