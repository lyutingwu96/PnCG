using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorManager : MonoBehaviour {

	public GameObject C;
	public GameObject Selected;
	public GameObject ansSubmitBut;
	public GameObject NW;

	// Use this for initialization
	void Start () {
		C.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}


	public void CalculatorOn(){
		C.SetActive (true);
		Selected.SetActive (true);
		//Selected.GetComponent<calculator>().enabled = true;
	}
	public void CalculatorOff(){
		C.SetActive (false);
		Selected.SetActive (false);
		ansSubmitBut.SetActive (false);
		//Selected.GetComponent<calculator>().enabled = false;
		//ansSubmitBut.GetComponent<compareAns>().enabled = false;
		//NW.GetComponent<RotateWithMouseWheel>().enabled = false;
	}

}
