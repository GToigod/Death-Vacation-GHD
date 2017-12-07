using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float speedratata;

	void Start () {
		
	}
	

	void Update () {
		if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.transform.Rotate (Vector3.left * speedratata * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.transform.Rotate (Vector3.left * speedratata * (-1) * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.Rotate (Vector3.up * speedratata * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.Rotate (Vector3.up * speedratata * (-1) * Time.deltaTime);
		}
	}
}
