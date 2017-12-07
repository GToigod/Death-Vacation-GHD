using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

public class PowerBar : MonoBehaviour {

	public float[] Speeds;
	public float StandardSpeed;
	private int reverse;
	bool PauseSeta;
	bool zonaVictory;
	bool zona;
	bool zonaLeft;
	bool zonaRight;
	bool SoundActive;
	//bool aniActive;
	public GameObject ButtonThrow;
	public GameObject NiceBarComponent;
	public Transform SetaStartPos;
	public Transform[] NicePoints;
	public Transform NicePointPos;
	public Animator ani;
	public Animator aniCharacter;
	PontuacaoBasket PBscript; 

	public AudiManager AudioM;
	public AudioManagerEffects AudioME;
	public ParticleSystem PS;


	void Start () {
		PBscript = GameObject.FindGameObjectWithTag ("Master").GetComponent<PontuacaoBasket> ();
		reverse = 1;
		PauseSeta = false;
		zonaVictory = false;
		zonaLeft = false;
		zonaRight = false;
		zona = false;
		SoundActive = false;
		//aniActive = false;
		NicePointPos = NicePoints [0];
		NiceBarComponent.transform.position = NicePointPos.position;
	}
	

	void Update () {
		if (PBscript.playBasket == false) {
			NiceBarComponent.transform.position = NicePoints[0].position;
			gameObject.transform.position = SetaStartPos.position;
			ButtonThrow.SetActive (false);
		}
		if (!aniCharacter.GetCurrentAnimatorStateInfo (0).IsName ("IdleBasket") && PBscript.playBasket == false) {
			aniCharacter.Play ("IdleBasket",0,0.0f);
		}

		if (PBscript.playBasket == true) {
			SetaClickOne ();
			ButtonThrow.SetActive (true);
		}

		if (PauseSeta == false && PBscript.playBasket == true) {
			SetaMove ();
		}



		if (zonaVictory == true) {
			if (ani.GetCurrentAnimatorStateInfo(0).IsName("BolaAcerto") &&
				ani.GetCurrentAnimatorStateInfo (0).normalizedTime * ani.GetCurrentAnimatorClipInfo (0).Length >= 0.99f*ani.GetCurrentAnimatorClipInfo (0).Length) {
				AudioME.AS.PlayOneShot (AudioME.AudiosBasket [0], 1.0f);
				PS.Emit (30);

				if (PBscript.playBasket) {
					Debug.Log ("Acertou ^^");
					PBscript.BasketPointsCurrent += 1;
				}
				ani.Play ("Cubeidle",0,0.0f);
				aniCharacter.Play ("IdleBasket",0,0.0f);
				NicePointPos = NicePoints [Random.Range(0,3)];
				NiceBarComponent.transform.position = NicePointPos.position;
				zonaVictory = false;
				gameObject.transform.position = SetaStartPos.position;
				PauseSeta = !PauseSeta;

			}


		}
		if (!zonaVictory && PauseSeta && zonaLeft) {
			if (ani.GetCurrentAnimatorStateInfo (0).IsName ("BallMissLeft") &&
			    ani.GetCurrentAnimatorStateInfo (0).normalizedTime * ani.GetCurrentAnimatorClipInfo (0).Length >= 0.85f * ani.GetCurrentAnimatorClipInfo (0).Length) {
				if (!SoundActive) {
					AudioME.AS.PlayOneShot (AudioME.AudiosBasket [1], 1.0f);
					SoundActive = true;
				}
			}
			if (ani.GetCurrentAnimatorStateInfo (0).IsName ("BallMissLeft") &&
			    ani.GetCurrentAnimatorStateInfo (0).normalizedTime * ani.GetCurrentAnimatorClipInfo (0).Length >= 0.99f * ani.GetCurrentAnimatorClipInfo (0).Length) {
				//AudioME.AS.PlayOneShot (AudioME.AudiosBasket [1], 1.0f);
				Debug.Log ("erroou!!");
				ani.Play ("Cubeidle",0,0.0f);
				aniCharacter.Play ("IdleBasket",0,0.0f);
				zonaLeft = false;
				SoundActive = false;
				NicePointPos = NicePoints [Random.Range(0,3)];
				NiceBarComponent.transform.position = NicePointPos.position;
				gameObject.transform.position = SetaStartPos.position;
				PauseSeta = !PauseSeta;

			}
		}
		if (!zonaVictory && PauseSeta && zonaRight) {
			if (ani.GetCurrentAnimatorStateInfo (0).IsName ("BallMissRight") &&
			    ani.GetCurrentAnimatorStateInfo (0).normalizedTime * ani.GetCurrentAnimatorClipInfo (0).Length >= 0.50f * ani.GetCurrentAnimatorClipInfo (0).Length) {
				if (!SoundActive) {
					AudioME.AS.PlayOneShot (AudioME.AudiosBasket [1], 1.0f);
					SoundActive = true;
				}
			}
			if (ani.GetCurrentAnimatorStateInfo (0).IsName ("BallMissRight") &&
				ani.GetCurrentAnimatorStateInfo (0).normalizedTime * ani.GetCurrentAnimatorClipInfo (0).Length >= 0.99f * ani.GetCurrentAnimatorClipInfo (0).Length) {
				//AudioME.AS.PlayOneShot (AudioME.AudiosBasket [1], 1.0f);
				Debug.Log ("erroou!!");
				ani.Play ("Cubeidle",0,0.0f);
				aniCharacter.Play ("IdleBasket",0,0.0f);
				zonaRight = false;
				SoundActive = false;
				NicePointPos = NicePoints [Random.Range(0,3)];
				NiceBarComponent.transform.position = NicePointPos.position;
				gameObject.transform.position = SetaStartPos.position;
				PauseSeta = !PauseSeta;

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
				aniCharacter.Play ("JogarBola",0,0.0f);
				ani.Play ("BolaAcerto",0,0.0f);


			}
			if (!zona && !PauseSeta) {
				PauseSeta = !PauseSeta;
				if (gameObject.transform.position.x >= NiceBarComponent.transform.position.x) {
					zonaLeft = true;
					aniCharacter.Play ("JogarBola",0,0.0f);
					ani.Play ("BallMissLeft", 0, 0.0f);
				}
				if (gameObject.transform.position.x < NiceBarComponent.transform.position.x) {
					zonaRight = true;
					aniCharacter.Play ("JogarBola",0,0.0f);
					ani.Play ("BallMissRight", 0, 0.0f);

				}
			}
		}
	}
	public void SetaClickTwo(){
		if (zona && !PauseSeta) {
			zonaVictory = true;
			PauseSeta = !PauseSeta;
			aniCharacter.Play ("JogarBola",0,0.0f);
			ani.Play ("BolaAcerto",0,0.0f);


		}
		if (!zona && !PauseSeta) {
			PauseSeta = !PauseSeta;
			if (gameObject.transform.position.x >= NiceBarComponent.transform.position.x) {
				zonaLeft = true;
				aniCharacter.Play ("JogarBola",0,0.0f);
				ani.Play ("BallMissLeft", 0, 0.0f);
			}
			if (gameObject.transform.position.x < NiceBarComponent.transform.position.x) {
				zonaRight = true;
				aniCharacter.Play ("JogarBola",0,0.0f);
				ani.Play ("BallMissRight", 0, 0.0f);

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
