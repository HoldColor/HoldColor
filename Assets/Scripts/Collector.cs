using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {
    public GameObject Player;
    public GameObject Hinge;
    public List<GameObject> Reserve;
    public List<GameObject> Turret;
    public List<GameObject> Field;
    public List<KeyValuePair> Others;


	// Use this for initialization
	private void Awake () {
        Player = GameObject.Find("Player");
        Hinge = GameObject.Find("Hinge");
        Reserve = new List<GameObject>();
        Turret = new List<GameObject>();
        Field = new List<GameObject>();
        Others = new List<KeyValuePair>();
    }

    public class KeyValuePair
    {
        public string key;
        public GameObject value;
    }
}
