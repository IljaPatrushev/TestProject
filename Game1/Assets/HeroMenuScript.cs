using UnityEngine;
using System.Collections;

public class HeroMenuScript : MonoBehaviour {

	Rigidbody2D rb;

	public int hyppy;
	public int speed;

	bool jump = true;
	bool up = false;
	bool down = false;
	bool left = false;
	bool right = false;



	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)){
			up = true;
		} 
		else up = false;
		
		if (Input.GetKey (KeyCode.S)){
			down = true;
		} 
		else down = false;
		
		if (Input.GetKey (KeyCode.D)){
			right = true;
		} 
		else right = false;
		
		if (Input.GetKey (KeyCode.A)){
			left = true;
		} 
		else left = false;
	
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.collider.tag == "Ground") {
			
			jump = true;
		}

		if (other.collider.tag == "StartMenuTag") {

			Application.LoadLevel (1);

		}

		if (other.collider.tag == "QuitMenuTag") {

			Application.Quit ();
		}

		if (other.collider.tag == "InvWall") {

			Application.LoadLevel (Application.loadedLevel);

		}
	}


	void FixedUpdate(){


		if (up) {
			if(jump){
				rb.AddForce (Vector2.up * hyppy);
				jump = false;
			}
		}
		if (down) {
			rb.AddForce (-transform.up * speed);
		}
		if (right) {
			rb.AddForce (transform.right * speed);
		}
		if (left) {
			rb.AddForce (-transform.right * speed);
		}

	}
}
