using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoldColor.Config;

public class AttackBuff : MonoBehaviour {
    private SFController OwnController;
    // Use this for initialization
    void Start () {
        OwnController = gameObject.GetComponent<SFController>();
        OwnController.type = SFController.SFType.Attack;
    }
	
	public void StartAttackBuff()
    {
        Collector collector = GameObject.Find("Collector").GetComponent<Collector>();
        PlayerInteractAction PIA = collector.Player.GetComponent<PlayerController>().Interact.GetComponentInChildren<PlayerInteractAction>();
        PIA.Damage = PIA.Damage * AttackSF._ImproveDamage;
        PIA.InteractAreaRadius = PIA.InteractAreaRadius * (1 + AttackSF._ImproveInteractRadius);
        foreach(GameObject Turret in collector.Turret)
        {
            TurretInteractAction TIA = Turret.GetComponent<TurretController>().Interact.GetComponentInChildren<TurretInteractAction>();
            TIA.Damage = TIA.Damage * AttackSF._ImproveDamage;
            TIA.InteractAreaRadius = TIA.InteractAreaRadius * (1 + AttackSF._ImproveInteractRadius);
        }
    }

    public void StopAttackBuff()
    {
        Collector collector = GameObject.Find("Collector").GetComponent<Collector>();
        PlayerInteractAction PIA = collector.Player.GetComponent<PlayerController>().Interact.GetComponent<PlayerInteractAction>();
        PIA.Damage = PlayerConfig._Damage;
        PIA.InteractAreaRadius = PlayerConfig._InteractAreaRadius;
        foreach (GameObject Turret in collector.Turret)
        {
            TurretInteractAction TIA = Turret.GetComponent<TurretController>().Interact.GetComponent<TurretInteractAction>();
            TIA.Damage = TurretConfig._Damage;
            TIA.InteractAreaRadius = TurretConfig._InteractAreaRadius;
        }
    }
}
