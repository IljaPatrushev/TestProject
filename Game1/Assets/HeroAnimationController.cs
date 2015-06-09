using UnityEngine;
using System.Collections;

public class HeroAnimationController : MonoBehaviour {

	public float maxSpeed = 10f;




	private Animator anim;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void FixedUpdate(){

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(move));



	}
}
