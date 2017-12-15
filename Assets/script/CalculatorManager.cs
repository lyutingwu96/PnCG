using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorManager : MonoBehaviour {

	public GameObject C;
	public GameObject CScript;

	// Use this for initialization
	void Start () {
		C.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}


	public void CalculatorOn(){
		C.SetActive (true);
		CScript.GetComponent<calculator>().enabled = true;
	}
	public void CalculatorOff(){
		C.SetActive (false);
		CScript.GetComponent<calculator>().enabled = false;
	}

}
