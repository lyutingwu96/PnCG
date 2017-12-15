using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class HeartControl : MonoBehaviour {

	public Flowchart flowchart;
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	private int heartNum;

	// Use this for initialization
	void Start() {
		getFlowchartNums ();
		if (heartNum == 3) {
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
		}else if (heartNum == 2) {
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (false);
		}else if (heartNum == 1) {
			heart1.SetActive (true);
			heart2.SetActive (false);
			heart3.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		getFlowchartNums ();
		if (heartNum == 3) {
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
		}else if (heartNum == 2) {
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (false);
		}else if (heartNum == 1) {
			heart1.SetActive (true);
			heart2.SetActive (false);
			heart3.SetActive (false);
		}
		
	}

	void getFlowchartNums(){
		heartNum = flowchart.GetIntegerVariable ("HeartNum");
	}
}
