using UnityEngine;
using System.Collections;

public class AndroidShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	float timer = 0;
	void shoot(){

		if (timer < Time.time) {

			GameObject tmp = Instantiate(Resources.Load("beam"), transform.position,transform.rotation) as GameObject;
			bullet tmp2 = tmp.GetComponent<bullet>();
			tmp2.speed = 80;
			tmp2.damage = 2;
			timer = Time.time + 0.25f;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Asteroid"){

			Vector3 lookat = other.transform.position - transform.position;
			float angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			shoot ();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
