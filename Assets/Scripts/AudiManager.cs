using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiManager : MonoBehaviour {

	public AudioSource AS;
	public AudioClip[] Audios;

	void Start () {
		AS = GetComponent<AudioSource> ();
	}
	

	void Update () {
		
	}
}
