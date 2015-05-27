using UnityEngine;
using System.Collections;

public class android1 : MonoBehaviour {

	Rigidbody2D rb;
	public GameObject target;
	public int speed;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 lookat = target.transform.position - transform.position;
		float angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	
	}
	void FixedUpdate () {
			rb.AddForce (transform.up *speed);
			rb.AddForce (transform.right * speed);
	}

}

