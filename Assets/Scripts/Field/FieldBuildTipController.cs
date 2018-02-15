using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoldColor.Config;

public class FieldBuildTipController : MonoBehaviour {

    private float Radius;
    private bool isBuildAbled;
    public bool IsBuildAbled
    {
        get
        {
            return isBuildAbled;
        }
        set
        {
            isBuildAbled = value;
        }
    }
    public GameObject FieldUIBTN;
    private bool FinalBuildAbled;
    // Use this for initialization
    void Start()
    {
        Radius = Field._HalfLength;
        gameObject.GetComponentInChildren<BuildAreaTip>().Radius = Radius;
        gameObject.GetComponentInChildren<BuildAreaTip>().Type = BuildAreaTip.BuildType.Field;
        gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingDiasbled;
        IsBuildAbled = false;
        FinalBuildAbled = true;
        FieldUIBTN = GameObject.Find("UI/BuildField");
    }
    private void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
        gameObject.transform.position = target;

        if (FinalBuildAbled && isBuildAbled)
        {
            gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingAbled;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingDiasbled;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (FinalBuildAbled && isBuildAbled)
            {   
                GameObject Turret = Resources.Load<GameObject>("Prefabs/Field");
                Instantiate(Turret, transform.position, transform.rotation);
                FieldUIBTN.GetComponent<Button>().interactable = true;
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("cant");
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("cancle");
            FieldUIBTN.GetComponent<Button>().interactable = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.BodyCollider)
        {
            FinalBuildAbled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.BodyCollider)
        {
            FinalBuildAbled = true;
        }
    }
}
