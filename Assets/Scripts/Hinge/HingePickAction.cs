using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingePickAction : MonoBehaviour {

    public enum HingeStatus
    {
        picked,
        unpicked,
        mouseOn
    }
    private InteractController interact;
    public HingeStatus Status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
            if (value == HingeStatus.picked) interact.ShowArea();
            else interact.HideArea();
        }
    }
    private HingeStatus _status;
    void Start()
    {
        _status = HingeStatus.unpicked;
        interact = gameObject.GetComponentInParent<HingeController>().Interact.GetComponent<InteractController>();
        interact.HideArea();
        this.gameObject.AddComponent<BoxCollider>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == this.gameObject)
        {
            if (_status == HingeStatus.unpicked)
            {
                _status = HingeStatus.mouseOn;
                interact.ShowArea();
            }
        }
        else
        {
            _status = HingeStatus.unpicked;
            interact.HideArea();
        }
    }
}
