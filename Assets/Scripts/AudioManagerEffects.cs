using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerEffects : MonoBehaviour {

	public AudioSource AS;
	public AudioClip[] AudiosMap;
	public AudioClip[] AudiosBasket;
	public AudioClip[] AudiosEquil;
	public AudioClip[] AudiosFish;

	void Start () {
		AS = GetComponent<AudioSource> ();
	}


	void Update () {

	}
}
