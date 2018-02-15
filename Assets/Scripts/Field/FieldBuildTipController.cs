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
    // Use this for initialization
    void Start()
    {
        Radius = Field._HalfLength;
        gameObject.GetComponentInChildren<BuildAreaTip>().Radius = Radius;
        gameObject.GetComponentInChildren<BuildAreaTip>().Type = BuildAreaTip.BuildType.Field;
        gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingDiasbled;
        IsBuildAbled = false;
        FieldUIBTN = GameObject.Find("UI/BuildField");
    }
    private void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
        gameObject.transform.position = target;

        if (Input.GetMouseButtonDown(0))
        {
            if (IsBuildAbled)
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
}
