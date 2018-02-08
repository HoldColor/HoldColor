using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private float _speed;
    public bool isHit;
    public bool isShoot;
    private int _damage;
    private Color _camp;
    public GameObject target;
    public Collider2D targetCollider;
    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
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
    public Color Camp
    {
        get
        {
            return _camp;
        }
        set
        {
            _camp = value;
            gameObject.GetComponent<SpriteRenderer>().color = value;
            Color TrailColor = value;
            TrailColor.a = 0.7f;
            gameObject.GetComponent<TrailRenderer>().startColor = TrailColor;
            gameObject.GetComponent<TrailRenderer>().endColor = TrailColor;
        }
    }
    // Use this for initialization
    void Awake()
    {
        isHit = false;
        target = null;
        _speed = 3.0f;
        _damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            Destroy(this.gameObject);
        }
        if (isShoot && target)
        {
            BulletMove(target);
        }
    }

    private void BulletMove(GameObject target)
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.z = 0;
        dir.Normalize();
        transform.position += dir * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == targetCollider)
        {
            isHit = true;
            targetCollider.GetComponent<ColliderController>().Info.GetComponent<StateBar>().ConsumeHealth(_damage);
            Destroy(this.gameObject);
        }
    }
}
