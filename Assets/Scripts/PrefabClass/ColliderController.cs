using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour {
    public enum ColliderType
    {
        BodyCollider,
        InteractCollider,
        BulletCollider,
        SFBodyCollider
    }
    public ColliderType Type;
    public GameObject GameBody;
    public GameObject Info;
    private Color _camp;
    public Color Camp
    {
        get
        {
            return _camp;
        }
        set
        {
            _camp = value;
        }
    }
}
