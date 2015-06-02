using UnityEngine;
using System.Collections;

public class Pokeball : MonoBehaviour {

	Rigidbody2D rb;

	public int speed;
	public int damage;
	public string tagb;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 5);

	}
	
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		rb.AddForce (-transform.right * speed);

	}
}
