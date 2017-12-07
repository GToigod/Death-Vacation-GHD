using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoldExample : MonoBehaviour, IPointerDownHandler, IPointerUpHandler  {

	public bool estaApertado;
	public bool activeButton;

	public virtual void OnPointerDown(PointerEventData Ped){
		Debug.Log ("Tap On");
		estaApertado = true;
		activeButton = true;
	}
	public virtual void OnPointerUp(PointerEventData Ped){
		Debug.Log ("Tap Off");
		estaApertado = false;
	}


}
