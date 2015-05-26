using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	Rigidbody2D rb;
	int angle;
	 int hp = 10;
	public float size = 1;
	public float speed;
	public int tDamage = 8;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		angle = Random.Range (0, 360);
		transform.localScale = new Vector3 (size, size, size);

	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag != "asteroid") {
			other.collider.SendMessageUpwards("takeDamage",tDamage,SendMessageOptions.DontRequireReceiver);

		}

	}
	
	// Update is called once per frame
	void Update () {

		transform.localScale = new Vector3 (size, size, size);
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	    rb.AddForce(transform.up * speed);
		if (hp <= 0) {
			Destroy (gameObject);
		}
	
	}

	void takeDamage (int d) {

		hp -= d;

	}
}
