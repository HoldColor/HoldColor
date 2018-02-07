using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private float _speed;
    public bool isHit;
    public bool isShoot;
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
            gameObject.GetComponent<TrailRenderer>().startColor = value;
            gameObject.GetComponent<TrailRenderer>().endColor = value;
        }
    }
    // Use this for initialization
    void Awake()
    {
        isHit = false;
        target = null;
        _speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
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
            targetCollider.GetComponent<ColliderController>().Info.GetComponent<StateBar>().ConsumeHealth(10);
            Destroy(this.gameObject);
        }
    }
}
