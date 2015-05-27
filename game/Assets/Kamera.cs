using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {
	// public Rigidbody2D target;
	GameObject target;

	// fsafas
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");

	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, transform.position.z);
	
	}
}
