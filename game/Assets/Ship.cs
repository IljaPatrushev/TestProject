using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	public Rigidbody2D rb;

	 
	public int speed;
	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;
	float timer = 0;

	bool shootside = false;

	Transform leftg;
	Transform rightg;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
		leftg = transform.Find ("Left");
		rightg = transform.Find ("Right");

	
	}

	void shoot() {

		if (timer < Time.time) {
			if(shootside){
				GameObject tmp = Instantiate(Resources.Load("Beam"),leftg.position,leftg.rotation) as GameObject; // призыв пули
				                             bullet tmp2 = tmp.GetComponent<bullet>(); // Создание пули
				                             tmp2.speed = 200; // скорость полета пули
											 tmp2.taga = transform.tag;
				                             shootside = false;
				                             timer = Time.time + 0.10f; // скорость вылета пули

				                            


			}else {
					GameObject tmp = Instantiate(Resources.Load ("beam"),rightg.position,rightg.rotation) as GameObject;
				bullet tmp2 = tmp.GetComponent<bullet>();
				tmp2.speed = 200;

					shootside = true;
					timer = Time.time +0.10f;


				}
			
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton(0)) {
						shoot ();
					}



		if (Input.GetKey (KeyCode.W)){
			up = true;
		} 
		else down = false;

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

	void FixedUpdate(){

		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 lookat = transform.position - mouse;
		float angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

			if(up){
				rb.AddForce(transform.up* speed);
	}
			if(down){
				rb.AddForce(-transform.up * speed);
			}
			if(right){
				rb.AddForce(transform.right * speed);
			}
			if(left){
				rb.AddForce(-transform.right * speed);
			}
}
	

		}
