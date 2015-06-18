using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {



	// Use this for initialization

	void OnGUI(){


		if (GUI.Button (new Rect (10,10, 100, 20), "Start")) {   // Screen.width/2,Screen.height/2 - 25

			Application.LoadLevel (1);

		}
		if (GUI.Button (new Rect (10,40, 100, 20), "Exit")) { // Screen.width/2,Screen.height/2 ,

			Application.Quit ();

		}

			
			
		






	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
