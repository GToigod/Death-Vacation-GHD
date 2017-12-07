using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontuacaoBasket : MonoBehaviour {

	public static int BasketPointsMax;
	public int BasketPointsCurrent;
	public Text BasketPointUI;
	public Text BasketPointUIMax;
	public Text BasketTimerUI;
	public float TimerPlay;
	public bool playBasket;
	public PowerBar PowerBarra;
	public GameObject ButtonPlay;

	public AudiManager AudioM;
	public AudioManagerEffects AudioME;

	void Start () {
		BasketPointsCurrent = 0;
		TimerPlay = 10.0f;
		playBasket = false;

	}
	

	void Update () {
		BasketPointUI.text = "Points: " + BasketPointsCurrent;
		BasketPointUIMax.text = "RecordPoints: " + BasketPointsMax;
		BasketTimerUI.text = "Time Left: " + TimerPlay.ToString("F2");

		if (Input.GetKeyDown (KeyCode.C) && playBasket == false && PowerBarra.enabled == true) {
			playBasket = true;
			ButtonPlay.SetActive (false);
		}
		if (playBasket) {
			StartBasket ();
		}
	}
	void StartBasket(){
		TimerPlay -= Time.deltaTime;
		if (TimerPlay <= 0.0f) {
			playBasket = false;
			ButtonPlay.SetActive (true);
			//PowerBarra.NiceBarComponent.transform.position = PowerBarra.NicePoints [0].position;
			//PowerBarra.gameObject.transform.position = PowerBarra.SetaStartPos.position;
			if (BasketPointsCurrent >= BasketPointsMax) {
				BasketPointsMax = BasketPointsCurrent;
			}
			BasketPointsCurrent = 0;
			TimerPlay = 10.0f;

		}

	}
	public void ClickToPlay(){
		if (playBasket == false && PowerBarra.enabled == true) {
			playBasket = true;
			ButtonPlay.SetActive (false);
		}

	}
}
