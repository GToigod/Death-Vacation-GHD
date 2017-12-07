using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControll : MonoBehaviour {

	PontuacaoBasket PBscript;
	PontuacaoEquilb PEscript;
	PontuacaoFish PFscript;
	public GameObject Seta;
	public Texture TextureFade;
	public float TimeFadeMax;
	float TimeFadeFlux;
	float A;

	public GameObject[] DesactiveObj;
	public GameObject[] ActiveObj;
	public GameObject[] ActiveObjBasket;
	public GameObject[] DesactiveObjBasket;
	public GameObject[] ActiveObjEquilb;
	public GameObject[] DesactiveObjEquilb;
	public GameObject[] ActiveObjFish;
	public GameObject[] DesactiveObjFish;


	bool FadeIn;
	bool FadeOut;

	bool ToMapBool;
	bool ToBasketBool;
	bool ToEquilibriumBool;
	bool ToFishingBool;
	//bool ToCannonballBool;

	bool mapArea;
	bool basketArea;
	bool EquilibiumArea;
	bool FishArea;
	//bool CannonArea;
	public AudiManager AudioM;
	public AudioManagerEffects AudioME;


	void Start () {
		PBscript = GameObject.FindGameObjectWithTag ("Master").GetComponent<PontuacaoBasket> ();
		PEscript = GameObject.FindGameObjectWithTag ("Master").GetComponent<PontuacaoEquilb> ();
		PFscript = GameObject.FindGameObjectWithTag ("Master").GetComponent<PontuacaoFish> ();
		FadeIn = false;
		FadeOut = false;
		TimeFadeFlux = 0;
		ToMapBool = false;
		ToBasketBool = false;
		AudioM.AS.clip = AudioM.Audios [Random.Range (0, 2)];
		AudioM.AS.Play ();
		ToEquilibriumBool = false;
		ToFishingBool = false;
		//ToCannonballBool = false;
	}
	

	void Update () {
		
	}


	void FadeStart(){
		if (FadeIn == false) {
			FadeIn = !FadeIn;
		}
	}
	public void ToMap(){
		if (!FadeIn && !ToMapBool && !PBscript.playBasket && !PEscript.playEquilb && !PFscript.playFish && !PFscript.playFishTwo) {
			FadeIn = true;
			ToMapBool = true;
			Seta.GetComponent<PowerBar> ().enabled = false;
			Seta.GetComponent<PowerBarEquilb> ().enabled = false;
			Seta.GetComponent<PowerBarFish> ().enabled = false;
			AudioM.AS.Stop ();
			AudioM.AS.clip = AudioM.Audios [Random.Range (0, 2)];
			AudioM.AS.Play ();
		}
	}
	public void ToBasket(){
		if (!FadeIn && !ToBasketBool && !PBscript.playBasket) {
			FadeIn = true;
			ToBasketBool = true;
			Seta.GetComponent<PowerBar> ().enabled = true;
			Seta.GetComponent<PowerBarEquilb> ().enabled = false;
			Seta.GetComponent<PowerBarFish> ().enabled = false;
			AudioM.AS.Stop ();
			AudioM.AS.clip = AudioM.Audios [2];
			AudioM.AS.Play ();
		}
	}
	public void ToEquilibrium(){
		if (!FadeIn && !ToEquilibriumBool && !PEscript.playEquilb) {
			FadeIn = true;
			ToEquilibriumBool = true;
			Seta.GetComponent<PowerBar> ().enabled = false;
			Seta.GetComponent<PowerBarEquilb> ().enabled = true;
			Seta.GetComponent<PowerBarFish> ().enabled = false;
			AudioM.AS.Stop ();
			AudioM.AS.clip = AudioM.Audios [3];
			AudioM.AS.Play ();
		}
	}
	public void ToFishing(){
		if (!FadeIn && !ToFishingBool && !PFscript.playFish && !PFscript.playFishTwo) {
			FadeIn = true;
			ToFishingBool = true;
			Seta.GetComponent<PowerBar> ().enabled = false;
			Seta.GetComponent<PowerBarEquilb> ().enabled = false;
			Seta.GetComponent<PowerBarFish> ().enabled = true;
			AudioM.AS.Stop ();
			AudioM.AS.clip = AudioM.Audios [4];
			AudioM.AS.Play ();
		}
	}
	public void QuitGameOW(){
		Application.Quit ();
		Debug.Log ("Fim de jogo");
	}




	void OnGUI(){
		if (FadeIn) {
			TimeFadeFlux += Time.deltaTime;
			A = TimeFadeFlux / TimeFadeMax;
			GUI.color = new Color (0, 0, 0, A);
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), TextureFade);
			if (TimeFadeFlux >= TimeFadeMax) {
				TimeFadeFlux = 0;
				FadeIn = false;
				FadeOut = true;
				if (ToMapBool) {
					for (int i = 0; i < DesactiveObj.Length; i++) {
						DesactiveObj [i].SetActive (false);
					}
					for (int i = 0; i < ActiveObj.Length; i++) {
						ActiveObj [i].SetActive (true);
					}

				}
				if (ToBasketBool) {
					for (int i = 0; i < ActiveObjBasket.Length; i++) {
						ActiveObjBasket [i].SetActive (true);
					}
					for (int i = 0; i < DesactiveObjBasket.Length; i++) {
						DesactiveObjBasket [i].SetActive (false);
					}


				}
				if (ToEquilibriumBool) {
					for (int i = 0; i < ActiveObjEquilb.Length; i++) {
						ActiveObjEquilb [i].SetActive (true);
					}
					for (int i = 0; i < DesactiveObjEquilb.Length; i++) {
						DesactiveObjEquilb [i].SetActive (false);
					}

				}
				if (ToFishingBool) {
					for (int i = 0; i < ActiveObjFish.Length; i++) {
						ActiveObjFish [i].SetActive (true);
					}
					for (int i = 0; i < DesactiveObjFish.Length; i++) {
						DesactiveObjFish [i].SetActive (false);
					}
			

				}
			}
		}
		if (FadeOut) {
			TimeFadeFlux += Time.deltaTime;
			A = 1 - TimeFadeFlux / TimeFadeMax;
			GUI.color = new Color (0, 0, 0, A);
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), TextureFade);
			if (TimeFadeFlux >= TimeFadeMax) {
				TimeFadeFlux = 0;
				FadeOut = false;
				ToMapBool = false;
				ToBasketBool = false;
				ToEquilibriumBool = false;
				ToFishingBool = false;

			}

		}


		}
}

