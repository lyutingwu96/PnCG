using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class RotateWithMouseWheel : MonoBehaviour {

	public Flowchart flowchart;
	private bool firstProblem;
	private int currentProblem;

	[SerializeField] private float rotateSpeed;
	[SerializeField] private Text NumStairs = null;
	[SerializeField] private Text NumPCH01 = null;
	[SerializeField] private Text NumPCH02 = null;
	[SerializeField] private Text NumFP = null;
	[SerializeField] private Text NumFP201 = null;
	[SerializeField] private Text NumFP202 = null;


	private int currentText = 0;
	private string num;

	void OnEnable(){
		getFlowchartNums ();
		/*NumStairs.text = " ";
		NumPCH01.text = " ";
		NumPCH02.text = " ";
		NumFP.text = " ";
		NumFP201.text = " ";
		NumFP202.text = " ";*/
	}

	void Update () {
		
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			transform.Rotate (new Vector3 (transform.rotation.x, transform.rotation.y, rotateSpeed));
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			transform.Rotate (new Vector3 (transform.rotation.x, transform.rotation.y, rotateSpeed * -1));
		}

		int currentAngle = (int)Mathf.Round (transform.eulerAngles.z);
		if ((currentAngle > 342) || (currentAngle <= 18)) {
			num = "0";
		}else if ((currentAngle > 18) && (currentAngle <= 54)) {
			num = "1";
		}else if ((currentAngle > 54) && (currentAngle <= 90)) {
			num = "2";
		}else if ((currentAngle > 90) && (currentAngle <= 126)) {
			num = "3";
		}else if ((currentAngle > 126) && (currentAngle <= 162)) {
			num = "4";
		}else if ((currentAngle > 162) && (currentAngle <= 198)) {
			num = "5";
		}else if ((currentAngle > 198) && (currentAngle <= 234)) {
			num = "6";
		}else if ((currentAngle > 234) && (currentAngle <= 270)) {
			num = "7";
		}else if ((currentAngle > 270) && (currentAngle <= 306)) {
			num = "8";
		}else if ((currentAngle > 306) && (currentAngle <= 342)) {
			num = "9";
		}
		/*
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

		}*/

		if (currentText == 1) {
			NumStairs.text = num;
		} else if (currentText == 2) {
			NumPCH01.text = num;
		} else if (currentText == 3) {
			NumPCH02.text = num;
		}else if (currentText == 4) {
			NumFP201.text = num;
		}else if (currentText == 5) {
			NumFP202.text = num;
		} else if (currentText == 0) {
			NumFP.text = num;
		}
			
	}

	void getFlowchartNums(){
		firstProblem = flowchart.GetBooleanVariable ("FirstProblem");
		currentProblem = flowchart.GetIntegerVariable ("CurrentProblem");

		if (firstProblem && (currentProblem != 2)) {
			currentText = 0;
		} else if (firstProblem && (currentProblem == 2)) {
			currentText = 4;
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
	public void currentFP201(){
		currentText = 4;
	}
	public void currentFP202(){
		currentText = 5;
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
