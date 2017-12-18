using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class calculator : MonoBehaviour {
	
	public Flowchart flowchart;

	public GameObject SkillFrameStairs;
	public GameObject SkillFramePCH;
	public GameObject SkillStairs;
	public GameObject SkillP;
	public GameObject SkillC;
	public GameObject SkillH;
	public GameObject NumberFrameStairs;
	public GameObject NumberFramePCH1;
	public GameObject NumberFramePCH2;
	public GameObject NumberFrameFP;
	public GameObject NumberFrameFP201;
	public GameObject NumberFrameFP202;


	public GameObject SkillChartStairs;
	public GameObject SkillChartP;
	public GameObject SkillChartC;
	public GameObject SkillChartH;
	public GameObject NW;
	public GameObject Hearts;

	[SerializeField] private Text NumStairs = null;
	[SerializeField] private Text NumPCH01 = null;
	[SerializeField] private Text NumPCH02 = null;
	[SerializeField] private Text NumFP = null;
	[SerializeField] private Text NumFP201 = null;
	[SerializeField] private Text NumFP202 = null;
	public GameObject ansSubmitB;

	public int FrameOn = 0;
	private int skillsNum;
	private int currentProblem;
	private bool firstProblem;
	private bool inExam;

	void OnEnable(){
		getFlowchartNums ();
		Debug.Log ("enabled");

		if (!inExam) {
			Hearts.SetActive (true);
		} else {
			Hearts.SetActive (false);
		}

		if ((skillsNum == 4) && !firstProblem) {
			SkillChartStairs.SetActive (true);
			SkillChartP.SetActive (true);
			SkillChartC.SetActive (true);
			SkillChartH.SetActive (true);
		} else if ((skillsNum == 3) && !firstProblem) {
			SkillChartStairs.SetActive (true);
			SkillChartP.SetActive (true);
			SkillChartC.SetActive (true);
		} else if ((skillsNum == 2) && !firstProblem) {
			SkillChartStairs.SetActive (true);
			SkillChartP.SetActive (true);
		} else if ((skillsNum == 1) && !firstProblem) {
			SkillChartStairs.SetActive (true);
		} else if(currentProblem == 2){
			NW.SetActive (true);
			//NW.GetComponent<RotateWithMouseWheel>().enabled = true;
			NumberFrameFP201.SetActive (true);
			NumberFrameFP202.SetActive (true);
		}else {
			NW.SetActive (true);
			//NW.GetComponent<RotateWithMouseWheel>().enabled = true;
			NumberFrameFP.SetActive (true);
		}
	}

	void Update(){
		if (firstProblem) {
			if (currentProblem == 2) {
				if ((NumFP201.text != " ") && (NumFP202.text != " ")) {
					ansSubmitB.SetActive (true);
				}
			}else{
			if (NumFP.text != " ") {
				ansSubmitB.SetActive (true);
				//ansSubmitB.GetComponent<compareAns>().enabled = true;
				}
			}
		} else {
			if (NumStairs.text != " ") {
				ansSubmitB.SetActive (true);
				//ansSubmitB.GetComponent<compareAns>().enabled = true;
			} else if ((NumPCH01.text != " ") && (NumPCH02.text != " ") && (int.Parse (NumPCH01.text) >= int.Parse (NumPCH02.text)) && GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 2) {
				ansSubmitB.SetActive (true);
				//ansSubmitB.GetComponent<compareAns>().enabled = true;
			} else if ((NumPCH01.text != " ") && (NumPCH02.text != " ") && (int.Parse (NumPCH01.text) >= int.Parse (NumPCH02.text)) && GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 3) {
				ansSubmitB.SetActive (true);
				//ansSubmitB.GetComponent<compareAns>().enabled = true;
			} else if ((NumPCH01.text != " ") && (NumPCH02.text != " ") && ((int.Parse (NumPCH01.text) + int.Parse (NumPCH02.text) - 1) >= int.Parse (NumPCH02.text)) && GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 4) {
				ansSubmitB.SetActive (true);
				//ansSubmitB.GetComponent<compareAns>().enabled = true;
			} else {
				ansSubmitB.SetActive (false);
				//ansSubmitB.GetComponent<compareAns>().enabled = false;
			}
		}
	}
	void getFlowchartNums(){
		skillsNum = flowchart.GetIntegerVariable ("SkillsNum");
		firstProblem = flowchart.GetBooleanVariable ("FirstProblem");
		inExam = flowchart.GetBooleanVariable ("InExam");
		currentProblem = flowchart.GetIntegerVariable ("CurrentProblem");
	}

	//!!!!!!!!!!!!!!!!!!!!!!!!!
	public void SkillFrameDisplayStairs(){
		SkillFrameStairs.SetActive(true);
		SkillStairs.SetActive(true);
		NumberFrameStairs.SetActive(true);

		if (FrameOn > 1) {
			SkillFramePCH.SetActive(false);
			NumberFramePCH1.SetActive(false);
			NumberFramePCH2.SetActive(false);
			SkillP.SetActive(false);
			SkillC.SetActive(false);
			SkillH.SetActive(false);
		}
		FrameOn = 1;
		
	}
	public void SkillFrameDisplayPCH(){
		SkillFramePCH.SetActive(true);
		NumberFramePCH1.SetActive(true);
		NumberFramePCH2.SetActive(true);

		if (FrameOn == 1) {
			SkillFrameStairs.SetActive(false);
			SkillStairs.SetActive(false);
			NumberFrameStairs.SetActive(false);
		}
	}
	//PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP
	public void SkillDisplayP(){
		SkillP.SetActive(true);
		SkillC.SetActive(false);
		SkillH.SetActive(false);
		FrameOn = 2;
	}
	//CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
	public void SkillDisplayC(){
		SkillP.SetActive(false);
		SkillC.SetActive(true);
		SkillH.SetActive(false);
		FrameOn = 3;
	}
	//HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
	public void SkillDisplayH(){
		SkillP.SetActive(false);
		SkillC.SetActive(false);
		SkillH.SetActive(true);
		FrameOn = 4;
	}


	public void NWDisplay(){
		SkillChartStairs.SetActive(false);
		SkillChartP.SetActive(false);
		SkillChartC.SetActive(false);
		SkillChartH.SetActive(false);
		NW.SetActive(true);
		//NW.GetComponent<RotateWithMouseWheel>().enabled = true;
	}
	public void SkillChartDisplay(){
		if ((skillsNum == 4) && !firstProblem) {
			SkillChartStairs.SetActive (true);
			SkillChartP.SetActive (true);
			SkillChartC.SetActive (true);
			SkillChartH.SetActive (true);
		} else if ((skillsNum == 3) && !firstProblem) {
			SkillChartStairs.SetActive (true);
			SkillChartP.SetActive (true);
			SkillChartC.SetActive (true);
		} else if ((skillsNum == 2) && !firstProblem) {
			SkillChartStairs.SetActive (true);
			SkillChartP.SetActive (true);
		} else if ((skillsNum == 1) && !firstProblem) {
			SkillChartStairs.SetActive (true);
		}
		NW.SetActive(false);
		//NW.GetComponent<RotateWithMouseWheel>().enabled = false;
	}
}
