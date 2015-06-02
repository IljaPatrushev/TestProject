using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Rigidbody2D rb;
	public int hp;

	// bool shootside = true;

	Transform eGung;

	float timer = 0;




	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		eGung = transform.Find ("eGun");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (1)) {
			eshoot ();
		}

	
	}

	void eshoot(){

		if (timer < Time.time) {

			GameObject tmp = Instantiate (Resources.Load ("Pokeball"), eGung.position, eGung.rotation) as GameObject;
			Pokeball tmp2 = tmp.GetComponent<Pokeball> ();
			tmp2.speed = 50;
			tmp2.tagb = transform.tag;
			timer = Time.time + 0.10f;
			
			
			
		}
		/* void OnTriggerStay2D(CircleCollider2D other){
		
		if(other.tag == "Player"){

				GameObject tmp = Instantiate (Resources.Load ("Pokeball"),eGung.position,eGung.rotation) as GameObject;
				Pokeball tmp3 = tmp.GetComponent<Pokeball>();
				tmp3.speed = 40;
				tmp3.tagb = transform.tag;
			}
		} */


		
		
	



	}

}