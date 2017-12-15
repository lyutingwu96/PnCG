using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class RotateWithMouseWheel : MonoBehaviour {

	public Flowchart flowchart;
	private bool firstProblem;

	[SerializeField] private float rotateSpeed;
	[SerializeField] private Text NumStairs = null;
	[SerializeField] private Text NumPCH01 = null;
	[SerializeField] private Text NumPCH02 = null;
	[SerializeField] private Text NumFP = null;


	private int currentText = 0;
	private string num;

	void Start(){
		getFlowchartNums ();
		NumStairs.text = " ";
		NumPCH01.text = " ";
		NumPCH02.text = " ";
		NumFP.text = " ";
	}

	void Update () {
		
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			transform.Rotate (new Vector3 (transform.rotation.x, transform.rotation.y, rotateSpeed));
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			transform.Rotate (new Vector3 (transform.rotation.x, transform.rotation.y, rotateSpeed * -1));
		}

		switch ((int)Mathf.Round(transform.eulerAngles.z))
		{
		case 0:
			num = "0";
			break;

		case 36:
			num = "1";
			break;

		case 72:
			num = "2";
			break;

		case 108:
			num = "3";
			break;

		case 144:
			num = "4";
			break;

		case 180:
			num = "5";
			break;

		case 216:
			num = "6";
			break;

		case 252:
			num = "7";
			break;

		case 288:
			num = "8";
			break;

		case 324:
			num = "9";
			break;

		default:
			num = " ";
			break;

		}

		if (currentText == 1) {
			NumStairs.text = num;
		} else if (currentText == 2) {
			NumPCH01.text = num;
		} else if (currentText == 3) {
			NumPCH02.text = num;
		} else if (currentText == 0) {
			NumFP.text = num;
		}
			
	}

	void getFlowchartNums(){
		firstProblem = flowchart.GetBooleanVariable ("FirstProblem");
		if (firstProblem) {
			currentText = 0;
		}
	}

	public void currentStairs(){
		currentText = 1;
	}
	public void currentPCH01(){
		currentText = 2;
	}
	public void currentPCH02(){
		currentText = 3;
	}
	public void currentReset(){
		currentText = 0;
	}
	public void numResetStairs(){
		NumPCH01.text = " ";
		NumPCH02.text = " ";
	}
	public void numResetPCH(){
		NumStairs.text = " ";
	}
		
}
