using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class PlayerInteractAction : MonoBehaviour {
    private GameObject Bullet;
    private Collider2D Target;
    private PlayerController OwnController;
    private InteractController interactController;
    private float _firingRate;
    private int _damage;
    private float _bulletSpeed;
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
    public float BulletSpeed
    {
        get
        {
            return _bulletSpeed;
        }
        set
        {
            _bulletSpeed = value;
        }
    }
    public int Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }
    public float FiringRate
    {
        get
        {
            return _firingRate;
        }
        set
        {
            _firingRate = value;
            if (IsInvoking())
            {
                CancelInvoke();
                InvokeRepeating("Shoot", 0, value);
            }
        }
    }
    // Use this for initialization
    void Start()
    {
        Bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        OwnController = gameObject.GetComponentInParent<PlayerController>();
        _firingRate = PlayerConfig._FiringRate;
        _damage = PlayerConfig._Damage;
        _bulletSpeed = PlayerConfig._BulletSpeed;
        _interactAreaRadius = PlayerConfig._InteractAreaRadius;
        interactController = gameObject.GetComponentInParent<InteractController>();
        interactController.InteractRadius = _interactAreaRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.BodyCollider && colliderController.Camp != OwnController.Camp)
        {
            Target = collision;
            InvokeRepeating("Shoot", 0, _firingRate);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == Target)
        {
            CancelInvoke();
        }
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.FieldBuildCollider)
        {
            CanBuild(false, colliderController, collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.FieldBuildCollider)
        {
            CanBuild(true, colliderController, collision);
        }
    }

    private void Shoot()
    {
        if (OwnController.Info.GetComponent<StateBar>().CurrentEnergy >= 10)
        {
            GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
            bullet.GetComponent<BulletController>().Damage = _damage;
            bullet.GetComponent<BulletController>().Speed = _bulletSpeed;
            //OwnController.Info.GetComponent<StateBar>().ConsumeEnergy(10);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            bulletController.target = Target.GetComponent<ColliderController>().GameBody;
            bulletController.targetCollider = Target;
            bulletController.isShoot = true;
            bulletController.Camp = OwnController.Camp;
        }
    }

    private void CanBuild(bool flag, ColliderController colliderController, Collider2D collision)
    {
        if (flag)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingAbled;
        }
        else
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingDiasbled;
        }
        switch (colliderController.Type)
        {
            case ColliderController.ColliderType.TurretBuildCollider:
                collision.gameObject.GetComponent<TurretBuildTipController>().IsBuildAbled = flag;
                break;
            case ColliderController.ColliderType.FieldBuildCollider:
                collision.gameObject.GetComponent<FieldBuildTipController>().IsBuildAbled = flag;
                break;
        }
    }
}
