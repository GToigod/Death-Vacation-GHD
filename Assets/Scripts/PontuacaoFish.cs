using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontuacaoFish : MonoBehaviour {

	public static int FishPointsMax;
	public int FishPointsCurrent;
	public Text FishPointUI;
	public Text FishPointUIMax;
	public Text FishTimerUI;
	public float TimerPlay;
	public float TimerPlayMax;
	public bool playFish;
	public bool playFishTwo;
	public PowerBarFish PowerBarra;
	public LoadingBar LoadBar;
	public GameObject ButtonPlay;
	public GameObject TheLoadBar;
	public GameObject ThePowerBar;
	//public GameObject ButtonPlayTwo;
	public AudiManager AudioM;
	public AudioManagerEffects AudioME;
	//public ParticleSystem PS;

	void Start () {
		FishPointsCurrent = 0;
		TimerPlay = TimerPlayMax;
		playFish = false;
		playFishTwo = false;
		//PS.Emit (30);

	}


	void Update () {
		FishPointUI.text = "Points: " + FishPointsCurrent;
		FishPointUIMax.text = "RecordPoints: " + FishPointsMax;
		FishTimerUI.text = "Time Left: " + TimerPlay.ToString("F2");

		if (playFish || playFishTwo) {
			StartFish ();
		}

	}
	void StartFish(){
		TimerPlay -= Time.deltaTime;
		if (TimerPlay <= 0.0f) {
			playFish = false;
			playFishTwo = false;
			AudioME.AS.Stop ();
			TheLoadBar.SetActive (false);
			ThePowerBar.SetActive (false);

			PowerBarra.PauseSeta = false;
			PowerBarra.zonaVictory = false;
			PowerBarra.zonaOut = false;
			PowerBarra.ButtonGetFish.SetActive (false);

			LoadBar.ButtonCarregar.SetActive (false);
			LoadBar.PauseSeta = false;
			LoadBar.gameObject.transform.position = LoadBar.SetaStartPos.position;

			ButtonPlay.SetActive (true);

			LoadBar.aniVara.Play("VaraIdle",0,0.0f);
			LoadBar.aniCharacter.Play("IdleBasket",0,0.0f);
			if (FishPointsCurrent >= FishPointsMax) {
				FishPointsMax = FishPointsCurrent;
			}
			FishPointsCurrent = 0;
			TimerPlay = TimerPlayMax;

		}

	}
	public void ClickToPlay(){
		if (playFish == false && playFishTwo == false) {
			TheLoadBar.SetActive (true);
			playFish = true;
			ButtonPlay.SetActive (false);
			//LoadBar.gameObject.transform.position = LoadBar.SetaStartPos.position;
		}

	}

}
