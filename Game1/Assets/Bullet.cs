using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Rigidbody2D rb;

	public int speed = 200;
	public int damage;
	public string taga;
	bool IFR;



	//public bool IsFacingRight;


	// Use this for initialization
	void Start () {

		IFR = Hero.IsFacingRight;
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 3);
	
	}



	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Enemy" || other.tag == "Ground") {


			other.SendMessageUpwards("takeDamage",damage, SendMessageOptions.DontRequireReceiver);

			Destroy (gameObject);		
		}
	}
	void FixedUpdate() {

		if (IFR == false) {

			rb.AddForce (transform.right * speed);

		}

		if (IFR == true) {

			rb.AddForce (-transform.right * speed);
		}




	

		// rb.AddForce (transform.right * speed);
	} 

	
	// Update is called once per frame
	void Update () {


	
	}
}
