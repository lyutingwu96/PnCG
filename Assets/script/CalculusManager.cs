using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculusManager : MonoBehaviour {

	public GameObject C;

	// Use this for initialization
	void Start () {
		C.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}


	public void CalculatorOn(){
		C.SetActive (true);
	}
	public void CalculatorOff(){
		C.SetActive (false);
	}

}
