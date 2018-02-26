using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBulletController : MonoBehaviour {
    private string id;
    private float _speed;
    public bool isHit;
    public bool isShoot;
    private int _damage;
    private Color _camp;
    public GameObject target;
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
        isShoot = false;
        _speed = 8.0f;
        _damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShoot && target)
        BulletMove(target);
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
        if (collision.gameObject.GetComponent<ColliderController>().GameBody == target
            && collision.gameObject.GetComponent<ColliderController>().Type == ColliderController.ColliderType.BodyCollider)
        {
            isHit = true;
            Destroy(this.gameObject);
        }
    }
}
