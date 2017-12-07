using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBarEquilb : MonoBehaviour {

	public float InitialSpeed;
	public float StandardSpeed;
	public float RecoverStamina;
	public float LostStamina;
	public float SpeedUp; 
	public int SpeedAni;
	private int reverse;
	bool PauseSeta;
	//bool zonaVictory;
	bool zona;
	//bool zonaLeft;
	//bool zonaRight;
	//bool aniActive;
	public GameObject ButtonEquilibrar;
	public GameObject NiceBarComponent;
	public Transform SetaStartPos;
	public Transform[] NicePoints;
	public Transform NicePointPos;
	//public Animator ani;
	public Animator aniCharacter;
	public Animator aniBook;
	PontuacaoEquilb PBscript;

	public AudiManager AudioM;
	public AudioManagerEffects AudioME;




	void Start () {
		SpeedAni = 1;
		PBscript = GameObject.FindGameObjectWithTag ("Master").GetComponent<PontuacaoEquilb> ();
		reverse = 1;
		PauseSeta = false;
		//zonaVictory = false;
		//zonaLeft = false;
		//zonaRight = false;
		zona = false;
		StandardSpeed = InitialSpeed;
		//aniActive = false;
		NicePointPos = NicePoints [0];
		NiceBarComponent.transform.position = NicePointPos.position;
	}


	void Update () {
		if (PBscript.playEquilb == false && !PBscript.fimjogo) {
			//aniCharacter.Play ("IdleEquibOne", 0, 0.0f);
			NiceBarComponent.transform.position = NicePoints[0].position;
			gameObject.transform.position = SetaStartPos.position;
			ButtonEquilibrar.SetActive (false);
		}

		if (PBscript.playEquilb == true && !PBscript.fimjogo) {
			SetaClickOne ();
			ButtonEquilibrar.SetActive (true);
		}

		if (PauseSeta == false && PBscript.playEquilb == true && !PBscript.fimjogo) {
			SetaMove ();
		}

		if (PBscript.Stamina > 0.6f * PBscript.MaxStamina && PBscript.Stamina <= PBscript.MaxStamina) {
			SpeedAni = 1;
		}
		if (PBscript.Stamina > 0.3f * PBscript.MaxStamina && PBscript.Stamina <= 0.6f*PBscript.MaxStamina) {
			SpeedAni = 2;
		}
		if (PBscript.Stamina > 0.0f * PBscript.MaxStamina && PBscript.Stamina <= 0.3f*PBscript.MaxStamina) {
			SpeedAni = 3;
		}

		if (SpeedAni == 1 && !aniCharacter.GetCurrentAnimatorStateInfo (0).IsName ("EqilOne") && PBscript.playEquilb == true && !PBscript.fimjogo ) {
			aniCharacter.Play("EqilOne",0,0.0f);
			aniBook.Play("EquilBookOne",0,0.0f);
		}
		if (SpeedAni == 2 && !aniCharacter.GetCurrentAnimatorStateInfo (0).IsName ("EqilTwo") && PBscript.playEquilb == true && !PBscript.fimjogo ) {
			aniCharacter.Play("EqilTwo",0,0.0f);
			aniBook.Play("EquilBookTwo",0,0.0f);
		}
		if (SpeedAni == 3 && !aniCharacter.GetCurrentAnimatorStateInfo (0).IsName ("EqilThree") && PBscript.playEquilb == true && !PBscript.fimjogo ) {
			aniCharacter.Play("EqilThree",0,0.0f);
			aniBook.Play("EquilBookThree",0,0.0f);
		}
		if (!aniCharacter.GetCurrentAnimatorStateInfo (0).IsName ("IdleEquil") && PBscript.playEquilb == false && !PBscript.fimjogo) {
			//aniCharacter.Play("IdleBasket",0,0.0f);
			aniCharacter.Play("IdleEquil",0,0.0f);
		}
		if (!aniBook.GetCurrentAnimatorStateInfo (0).IsName ("IdleBook") && PBscript.playEquilb == false && !PBscript.fimjogo) {
			aniBook.Play("IdleBook",0,0.0f);
		}


	}


	void SetaMove(){
		transform.Translate (transform.InverseTransformDirection(Vector3.left) * reverse * StandardSpeed * Time.deltaTime, Space.World);
	}
	void SetaClickOne(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (zona && !PauseSeta) {
				PBscript.Stamina += RecoverStamina;
				NicePointPos = NicePoints [Random.Range(0,3)];
				NiceBarComponent.transform.position = NicePointPos.position;
				gameObject.transform.position = SetaStartPos.position;
				StandardSpeed += SpeedUp;
				if (StandardSpeed >= 4.0f) {
					StandardSpeed = 4.0f;
				}



			}

			if (!zona && !PauseSeta) {
				PBscript.Stamina -= LostStamina;
				NicePointPos = NicePoints [Random.Range(0,3)];
				NiceBarComponent.transform.position = NicePointPos.position;
				gameObject.transform.position = SetaStartPos.position;
			}
		}
	}
	public void SetaClickTwo(){
		
		if (zona && !PauseSeta && !PBscript.fimjogo) {
			PBscript.Stamina += RecoverStamina;
			NicePointPos = NicePoints [Random.Range(0,3)];
			NiceBarComponent.transform.position = NicePointPos.position;
			gameObject.transform.position = SetaStartPos.position;
			StandardSpeed += SpeedUp;
			if (StandardSpeed >= 4.0f) {
				StandardSpeed = 4.0f;
			}


		}

		if (!zona && !PauseSeta && !PBscript.fimjogo) {
			PBscript.Stamina -= LostStamina;
			NicePointPos = NicePoints [Random.Range(0,3)];
			NiceBarComponent.transform.position = NicePointPos.position;
			gameObject.transform.position = SetaStartPos.position;
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
