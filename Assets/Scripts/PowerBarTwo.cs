using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBarTwo : MonoBehaviour {
	
	public float[] Speeds;
	public float StandardSpeed;
	private int reverse;
	bool PauseSeta;
	bool zonaVictory;
	bool zona;



	void Start () {
		reverse = 1;
		PauseSeta = true;
		zonaVictory = false;
		zona = false;
	}


	void Update () {
		
	    SetaMove ();
		
		//SetaClickOne ();
		if (zonaVictory == true) {
			zonaVictory = false;
			Debug.Log ("Acertou ^^");
		}

	}

	void SetaMove(){
		if (Input.GetMouseButton (0)) {
			PauseSeta = false;
			transform.Translate (Vector3.left * reverse * StandardSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetMouseButtonUp (0)) {
			if (zona && !PauseSeta) {
				zonaVictory = true;
			}
			PauseSeta = true;

		}
	}
	void SetaClickOne(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (zona && !PauseSeta) {
				zonaVictory = true;
			}


		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "LimitBar") {
			reverse = reverse * (-1);
		}
		if (other.tag == "acerto") {
			zona = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "acerto") {
			zona = false;
		}
	}



}
