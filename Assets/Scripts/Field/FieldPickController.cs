using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldPickController : MonoBehaviour {

    public enum FieldStatus
    {
        picked,
        unpicked,
        mouseOn
    }
    private FieldAreaController interact;
    public FieldStatus Status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
            if (value == FieldStatus.picked) interact.ShowArea();
            else interact.HideArea();
        }
    }
    private FieldStatus _status;
    void Start()
    {
        _status = FieldStatus.unpicked;
        interact = gameObject.GetComponentInChildren<FieldAreaController>();
        interact.HideArea();
        this.gameObject.AddComponent<BoxCollider>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == this.gameObject)
        {
            if (_status == FieldStatus.unpicked)
            {
                _status = FieldStatus.mouseOn;
                interact.ShowArea();
            }
        }
        else
        {
            _status = FieldStatus.unpicked;
            interact.HideArea();
        }
    }
}
