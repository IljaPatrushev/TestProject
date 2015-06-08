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
		Destroy (gameObject, 3);

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			
			
			other.SendMessageUpwards("takeDamage",damage, SendMessageOptions.DontRequireReceiver);
			
			Destroy (gameObject);		
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		rb.AddForce (-transform.right * speed);

	}
}
