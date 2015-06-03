using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	public Rigidbody2D rb;
	public int speed;
	public int hyppy;

	bool jump = true;
	bool up = false;
	bool down = false;
	bool left = false;
	bool right = false;
	//bool shootside = true;

	Transform gung;


	float timer = 0;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		gung = transform.Find ("Gun");
	
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

		if(Input.GetMouseButton(0)) {
			shoot ();
		}
	
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.collider.tag == "Ground" || other.collider.tag == "Enemy") {

			jump = true;
		}

	
	}

	void shoot(){
		//Debug.Log ("text");
		if (timer < Time.time) {


				GameObject tmp = Instantiate (Resources.Load ("beam"),gung.position,gung.rotation) as GameObject;
				Bullet tmp2 = tmp.GetComponent<Bullet>();
				tmp2.speed = 200;
				tmp2.taga = transform.tag;
				timer = Time.time +0.10f;


		}

	}

	void FixedUpdate () {



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
