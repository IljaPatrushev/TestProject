using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ship : MonoBehaviour {
	public Rigidbody2D rb;

	 
	public int speed;
	bool up = false;
	bool down = false;
	bool right = false;
	bool left = false;
	float timer = 0;
	public int hp = 100;
	GameObject canvas;

	bool shootside = false;

	Transform leftg;
	Transform rightg;
	GameObject androids;

	// Use this for initialization
	void Start () {
		androids = GameObject.Find ("Canvas/androidit");
		rb = GetComponent<Rigidbody2D> ();	
		leftg = transform.Find ("Left");
		rightg = transform.Find ("Right");

		canvas = GameObject.Find ("Canvas/HP");

	
	}

	void takeDamage (int d){
		hp -= d;

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
	int androidit = 0;
	
	// Update is called once per frame
	void Update () {

		androids.GetComponent<Text> ().text = "Androidit: " + androidit.ToString();
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject tmp = Instantiate (Resources.Load ("android1"), transform.position, transform.rotation) as GameObject;
			android1 tmp2 = tmp.GetComponent<android1>();
			tmp2.target = gameObject;
			androidit++;

			
		}

		canvas.GetComponent<Text> ().text = hp.ToString ();
		
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
