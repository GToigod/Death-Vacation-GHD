using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : MonoBehaviour {

	public float InitialSpeed;
	public float StandardSpeed;
	public float SpeedUp; 
	private int reverse;
	public bool PauseSeta;
	//bool zona;
	bool carregarAni;
	public GameObject ButtonCarregar;
	public GameObject ThisBar;
	public GameObject OtherBar;
	public Transform SetaStartPos;
	public Transform[] NicePoints;
	//public Transform NicePointPos;
	public Animator aniVara;
	public Animator aniCharacter;
	//public Animator aniBook;
	PontuacaoFish PFscript;
	public HoldExample HE;
	public PowerBarFish PBFscript;
	public AudiManager AudioM;
	public AudioManagerEffects AudioME;



	void Start () {
		
		PFscript = GameObject.FindGameObjectWithTag ("Master").GetComponent<PontuacaoFish> ();
		//PBFscript = OtherBar.GetComponent<PowerBarFish> ();
		reverse = 1;
		PauseSeta = false;
		//zona = false;
		carregarAni = false;
		StandardSpeed = InitialSpeed;
		//AudioM.AS.PlayOneShot (AudioM.Audios [0], 0.5f);

	}


	void Update () {
		if (PFscript.playFish == false) {
	
			//gameObject.transform.position = SetaStartPos.position;
			ButtonCarregar.SetActive (false);
		}

		if (PFscript.playFish == true) {
			
			ButtonCarregar.SetActive (true);
		}
			
		if (PFscript.playFish) {
			SetaMoveTwo ();
		}

		if (PauseSeta) {
			if (aniVara.GetCurrentAnimatorStateInfo (0).IsName ("LancarVara") &&
				aniVara.GetCurrentAnimatorStateInfo (0).normalizedTime * aniVara.GetCurrentAnimatorClipInfo (0).Length >= 0.99f * aniVara.GetCurrentAnimatorClipInfo (0).Length) {
			
				PauseSeta = false;
				ButtonCarregar.SetActive (false);
				PFscript.playFish = false;
				PFscript.playFishTwo = true;
				gameObject.transform.position = SetaStartPos.position;
				aniVara.Play ("VaraIdle", 0, 0.0f);
				aniCharacter.Play("IdleBasket", 0, 0.0f);
				OtherBar.SetActive (true);
				PBFscript.StandardSpeed = PBFscript.Speeds [PBFscript.SpeedNivelControl];
				ThisBar.SetActive (false);



			}
		}

	}


	void SetaMove(){
		if (Input.GetKey(KeyCode.P) && PauseSeta == false) {
			if (!carregarAni) {
				aniVara.Play ("CarregarVara", 0, 0.0f);
				//aniCharacter.Play("Caiu",0,0.0f);
				aniCharacter.Play("AtirarBoom",0,0.0f);
			}
		
			carregarAni = true;
			transform.Translate (transform.InverseTransformDirection (Vector3.left) * reverse * StandardSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKeyUp(KeyCode.P) && PauseSeta == false) {
			PauseSeta = true;
			carregarAni = false;
			aniCharacter.Play("IdleBasket",0,0.0f);
			aniVara.Play("LancarVara",0,0.0f);
			if (gameObject.transform.position.x <= NicePoints [0].transform.position.x) {
				PBFscript.SpeedNivelControl = 0;
			}
			if (gameObject.transform.position.x > NicePoints [0].transform.position.x && gameObject.transform.position.x <= NicePoints [1].transform.position.x  ) {
				PBFscript.SpeedNivelControl = 1;
			}
			if (gameObject.transform.position.x > NicePoints [1].transform.position.x && gameObject.transform.position.x <= NicePoints [2].transform.position.x  ) {
				PBFscript.SpeedNivelControl = 2;
			}
			if (gameObject.transform.position.x > NicePoints [2].transform.position.x) {
				PBFscript.SpeedNivelControl = 3;
			}

		}
	}
	void SetaMoveTwo(){
		if (HE.activeButton && HE.estaApertado && PauseSeta == false) {
			if (!carregarAni) {
				aniVara.Play ("CarregarVara", 0, 0.0f);
				//aniCharacter.Play("Caiu",0,0.0f);
				aniCharacter.Play("AtirarBoom",0,0.0f);
			}

			carregarAni = true;
			transform.Translate (transform.InverseTransformDirection (Vector3.left) * reverse * StandardSpeed * Time.deltaTime, Space.World);
		}
		if (HE.activeButton && !HE.estaApertado && PauseSeta == false) {
			PauseSeta = true;
			carregarAni = false;
			HE.activeButton = false;
			aniCharacter.Play("IdleBasket",0,0.0f);
			aniVara.Play("LancarVara",0,0.0f);
			if (gameObject.transform.position.x <= NicePoints [0].transform.position.x) {
				PBFscript.SpeedNivelControl = 0;
			}
			if (gameObject.transform.position.x > NicePoints [0].transform.position.x && gameObject.transform.position.x <= NicePoints [1].transform.position.x  ) {
				PBFscript.SpeedNivelControl = 1;
			}
			if (gameObject.transform.position.x > NicePoints [1].transform.position.x && gameObject.transform.position.x <= NicePoints [2].transform.position.x  ) {
				PBFscript.SpeedNivelControl = 2;
			}
			if (gameObject.transform.position.x > NicePoints [2].transform.position.x) {
				PBFscript.SpeedNivelControl = 3;
			}
			AudioME.AS.clip = AudioME.AudiosFish [0];
			AudioME.AS.time = 2.0f;
			AudioME.AS.Play ();
			//AudioME.AS.PlayScheduled (3.4f);

		}
	}





	void OnTriggerEnter(Collider other){
		if (other.tag == "LimitBar") {
			reverse = reverse * (-1);
		}
	}




}
