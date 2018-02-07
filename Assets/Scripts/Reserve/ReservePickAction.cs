using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservePickAction : MonoBehaviour {

	public enum ReserveStatus
    {
        picked,
        unpicked,
        mouseOn
    }
    private InteractController interact;
    public ReserveStatus Status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
            if (value == ReserveStatus.picked) interact.ShowArea();
            else interact.HideArea();
        }
    }
    private ReserveStatus _status;
	void Start () {
        _status = ReserveStatus.unpicked;
        interact = GameObject.Find("ReserveController").GetComponent<ReserveController>().Interact.GetComponent<InteractController>();
        interact.HideArea();
        this.gameObject.AddComponent<BoxCollider>();
	}

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == this.gameObject)
        {
            if (_status == ReserveStatus.unpicked)
            {
                _status = ReserveStatus.mouseOn;
                interact.ShowArea();
            }
        }
        else
        {
            _status = ReserveStatus.unpicked;
            interact.HideArea();
        }
    }
}
