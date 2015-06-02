using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Rigidbody2D rb;

	public int speed = 200;
	public int damage;
	public string taga;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 5);
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "Player") {
			other.SendMessageUpwards("takeDamage", damage,SendMessageOptions.DontRequireReceiver);
			
		}
	}

	void FixedUpdate() {

		rb.AddForce (transform.right * speed);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
