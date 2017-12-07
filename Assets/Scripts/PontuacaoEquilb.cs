using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontuacaoEquilb : MonoBehaviour {

	public static float EquilbRecord;
	public float EquilbPointsCurrent;
	public Text EquilbPointUI;
	public Text EquilbPointUIMax;
	public Text EquilbTimerUI;
	public Text StaminaDisplayUI;
	public float TimerPlay;
	public float MaxStamina;
	public float Stamina;
	public bool playEquilb;
	public PowerBarEquilb PowerBarraEquilb;
	public GameObject ButtonPlay;

	public AudiManager AudioM;
	public AudioManagerEffects AudioME;

	public bool fimjogo;


	void Start () {
		EquilbPointsCurrent = 0;
		TimerPlay = 0.0f;
		playEquilb = false;
		Stamina = MaxStamina;
		fimjogo = false;

	}


	void Update () {
		EquilbPointUI.text = "Points: " + EquilbPointsCurrent.ToString("F2");
		EquilbPointUIMax.text = "RecordPoints: " + EquilbRecord;
		EquilbTimerUI.text = "Time Left: " + TimerPlay.ToString("F2") + " seconds";
		StaminaDisplayUI.text = "STAMINA( " + Stamina.ToString ("F1") + "/" + MaxStamina + " )";

		if (Input.GetKeyDown (KeyCode.C) && playEquilb == false && PowerBarraEquilb.enabled == true) {
			PowerBarraEquilb.aniCharacter.Play("EqilOne",0,0.0f);
			PowerBarraEquilb.StandardSpeed = PowerBarraEquilb.InitialSpeed;
			playEquilb = true;
			ButtonPlay.SetActive (false);
		}
		if (playEquilb) {
			StartEquilb ();

		}
	}
	void StartEquilb(){
		if (!fimjogo) {
			TimerPlay += Time.deltaTime;
			Stamina -= Time.deltaTime;
		}
		if (Stamina >= MaxStamina) {
			Stamina = MaxStamina;
		}
		EquilbPointsCurrent = TimerPlay;
		if (Stamina <= 0.0f) {
			if (!fimjogo) {
				PowerBarraEquilb.aniCharacter.Play("Caiu",0,0.0f);
				PowerBarraEquilb.aniBook.Play ("Caiu", 0, 0.0f);
			}
			fimjogo = true;
			if (fimjogo && PowerBarraEquilb.aniCharacter.GetCurrentAnimatorStateInfo (0).IsName ("Caiu") &&
				PowerBarraEquilb.aniCharacter.GetCurrentAnimatorStateInfo (0).normalizedTime * PowerBarraEquilb.aniCharacter.GetCurrentAnimatorClipInfo (0).Length >= 0.99f * PowerBarraEquilb.aniCharacter.GetCurrentAnimatorClipInfo (0).Length) {
				playEquilb = false;
				//PowerBarraEquilb.aniBook.Play ("IdleEquil", 0, 0.0f);
				PowerBarraEquilb.aniBook.Play ("IdleBook", 0, 0.0f);
				PowerBarraEquilb.StandardSpeed = PowerBarraEquilb.InitialSpeed;
				ButtonPlay.SetActive (true);
				if (EquilbPointsCurrent >= EquilbRecord) {
					EquilbRecord = EquilbPointsCurrent;
				}
				EquilbPointsCurrent = 0;
				Stamina = MaxStamina;
				TimerPlay = 0.0f;
				fimjogo = false;
			}

		}

	}
	public void ClickToPlay(){
		if (playEquilb == false && PowerBarraEquilb.enabled == true) {
			PowerBarraEquilb.StandardSpeed = PowerBarraEquilb.InitialSpeed;
			//PowerBarraEquilb.aniCharacter.Play("EqilOne",0,0.0f);
			playEquilb = true;
			ButtonPlay.SetActive (false);
		}

	}
}
