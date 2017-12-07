using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBarFish : MonoBehaviour {

	public float[] Speeds;
	public int[] FishPoints;
	public float StandardSpeed;
	private int reverse;
	public int SpeedNivelControl;
	public bool PauseSeta;
	public bool zonaVictory;
	public bool zonaOut;
	bool zona;

	//bool aniActive;
	public GameObject ThisBar;
	public GameObject OtherBar;
	public GameObject ButtonGetFish;
	public GameObject NiceBarComponent;
	public Transform SetaStartPos;
	public Transform[] NicePoints;
	public Transform NicePointPos;
	public Animator aniVara;
	public Animator aniCharacter;
	PontuacaoFish PFscript; 
	public AudiManager AudioM;
	public AudioManagerEffects AudioME;
	public ParticleSystem PS;



	void Start () {
		PFscript = GameObject.FindGameObjectWithTag ("Master").GetComponent<PontuacaoFish> ();
		reverse = 1;
		PauseSeta = false;
		zonaVictory = false;
		zonaOut = false;
		zona = false;
		//SpeedNivelControl = 0;
		//StandardSpeed = Speeds [SpeedNivelControl];
		//aniActive = false;
		NicePointPos = NicePoints [0];
		NiceBarComponent.transform.position = NicePointPos.position;
		gameObject.transform.position = SetaStartPos.position;

	}


	void Update () {
		
		//StandardSpeed = Speeds [SpeedNivelControl];

		if (PFscript.playFishTwo == false) {
			NiceBarComponent.transform.position = NicePoints[0].position;
			gameObject.transform.position = SetaStartPos.position;
			ButtonGetFish.SetActive (false);
		}


		if (PFscript.playFishTwo == true) {
			//SetaClickOne ();
			ButtonGetFish.SetActive (true);
		}


		if (PauseSeta == false && PFscript.playFishTwo == true) {
			SetaMove ();
		}



		if (zonaVictory == true) {
			if (aniVara.GetCurrentAnimatorStateInfo(0).IsName("CarregarVara") &&
				aniVara.GetCurrentAnimatorStateInfo (0).normalizedTime * aniVara.GetCurrentAnimatorClipInfo (0).Length >= 0.99f*aniVara.GetCurrentAnimatorClipInfo (0).Length) {
				AudioME.AS.Stop ();
				AudioME.AS.PlayOneShot (AudioME.AudiosFish [1], 1.0f);
				PS.Emit (30);
				zonaVictory = false;
				PauseSeta = !PauseSeta;
				if (PFscript.playFishTwo) {
					Debug.Log ("Acertou ^^");
					PFscript.FishPointsCurrent += FishPoints[SpeedNivelControl];
					PFscript.playFishTwo = false;
					PFscript.playFish = true;
				}
				ButtonGetFish.SetActive (false);
				gameObject.transform.position = SetaStartPos.position;
				aniVara.Play ("VaraIdle",0,0.0f);
				aniCharacter.Play ("IdleBasket",0,0.0f);
				OtherBar.SetActive (true);
				ThisBar.SetActive (false);


			}


		}
		if (!zonaVictory && PauseSeta && zonaOut) {
			if (aniVara.GetCurrentAnimatorStateInfo (0).IsName ("CarregarVara") &&
				aniVara.GetCurrentAnimatorStateInfo (0).normalizedTime * aniVara.GetCurrentAnimatorClipInfo (0).Length >= 0.99f * aniVara.GetCurrentAnimatorClipInfo (0).Length) {
				AudioME.AS.Stop ();
				zonaOut = false;
				gameObject.transform.position = SetaStartPos.position;
				PauseSeta = !PauseSeta;
				if (PFscript.playFishTwo) {
					Debug.Log ("erroou!!");
					PFscript.playFishTwo = false;
					PFscript.playFish = true;
				}
				ButtonGetFish.SetActive (false);
				aniVara.Play ("VaraIdle",0,0.0f);
				aniCharacter.Play ("IdleBasket",0,0.0f);
				OtherBar.SetActive (true);
				ThisBar.SetActive (false);


			}
		}
	

	}


	void SetaMove(){
		transform.Translate (transform.InverseTransformDirection(Vector3.left) * reverse * StandardSpeed * Time.deltaTime, Space.World);
	}
	void SetaClickOne(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (zona && !PauseSeta) {
				zonaVictory = true;
				PauseSeta = !PauseSeta;
				aniCharacter.Play ("Caiu",0,0.0f);
				aniVara.Play ("CarregarVara",0,0.0f);



			}
			if (!zona && !PauseSeta) {
				zonaOut = true;
				PauseSeta = !PauseSeta;
				aniCharacter.Play ("Caiu",0,0.0f);
				aniVara.Play ("CarregarVara",0,0.0f);

				

			}
		}
	}
	public void SetaClickTwo(){
		if (zona && !PauseSeta && PFscript.playFishTwo) {
			zonaVictory = true;
			PauseSeta = !PauseSeta;
			aniCharacter.Play ("Caiu",0,0.0f);
			aniVara.Play ("CarregarVara",0,0.0f);


		}
		if (!zona && !PauseSeta && PFscript.playFishTwo) {
			zonaOut = true;
			PauseSeta = !PauseSeta;
			aniCharacter.Play ("Caiu",0,0.0f);
			aniVara.Play ("CarregarVara",0,0.0f);


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
