using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoldColor.Config;

public class TurretBuildTipController : MonoBehaviour {
    private float Radius;
    private bool IsBuildAbled;
    public GameObject TurretUIBTN;
	// Use this for initialization
	void Start () {
        Radius = TurretConfig._InteractAreaRadius;
        gameObject.GetComponentInChildren<BuildAreaTip>().Radius = Radius;
        gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingDiasbled;
        IsBuildAbled = false;
        TurretUIBTN = GameObject.Find("UI/BuildTurret");
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
                GameObject Turret = Resources.Load<GameObject>("Prefabs/Turret");
                Instantiate(Turret, transform.position, transform.rotation);
                TurretUIBTN.GetComponent<Button>().interactable = true;
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
            TurretUIBTN.GetComponent<Button>().interactable = true;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.FieldCollider)
        {
            gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingDiasbled;
            IsBuildAbled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ColliderController colliderController = collision.gameObject.GetComponent<ColliderController>();
        if (colliderController.Type == ColliderController.ColliderType.FieldCollider)
        {
            gameObject.GetComponent<SpriteRenderer>().color = UI._BuildingAbled;
            IsBuildAbled = true;
        }
    }
}
