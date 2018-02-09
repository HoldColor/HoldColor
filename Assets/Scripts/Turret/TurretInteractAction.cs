using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class TurretInteractAction: MonoBehaviour {

    private GameObject Bullet;
    private List<Collider2D> Targets;
    private Collider2D Target;
    private TurretController OwnController;
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
        OwnController = gameObject.GetComponentInParent<TurretController>();
        _firingRate = TurretConfig._FiringRate;
        _damage = TurretConfig._Damage;
        _bulletSpeed = TurretConfig._BulletSpeed;
        _interactAreaRadius = TurretConfig._InteractAreaRadius;
        interactController = gameObject.GetComponentInParent<InteractController>();
        interactController.InteractRadius = _interactAreaRadius;
        Targets = new List<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.BodyCollider && colliderController.Camp != OwnController.Camp)
        {
            if (Targets.Count == 0)
            {
                if (!IsInvoking())
                {
                    Target = collision;
                    InvokeRepeating("Shoot", 0, _firingRate);
                }
            }
            Targets.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Targets.Contains(collision))
        {
            Targets.Remove(collision);
            if (collision == Target)
            {
                Target = null;
            }
            if (Targets.Count == 0)
            {
                CancelInvoke();
            }
        }
    }

    private void Shoot()
    {
        if (OwnController.Info.GetComponent<StateBar>().CurrentEnergy >= 10)
        {
            GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
            bullet.GetComponent<BulletController>().Damage = _damage;
            bullet.GetComponent<BulletController>().Speed = _bulletSpeed;
            OwnController.Info.GetComponent<StateBar>().ConsumeEnergy(10);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            if(Target == null)
            {
                Target = Targets[0];
            }
            bulletController.target = Target.GetComponent<ColliderController>().GameBody;
            bulletController.targetCollider = Target;
            bulletController.isShoot = true;
            bulletController.Camp = OwnController.Camp;
        }
    }
}
