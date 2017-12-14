using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculator : MonoBehaviour {
	
	public GameObject SkillFrameStairs;
	public GameObject SkillFramePCH;
	public GameObject SkillStairs;
	public GameObject SkillP;
	public GameObject SkillC;
	public GameObject SkillH;
	public GameObject NumberFrameStairs;
	public GameObject NumberFramePCH1;
	public GameObject NumberFramePCH2;


	public GameObject SkillChartStairs;
	public GameObject SkillChartP;
	public GameObject SkillChartC;
	public GameObject SkillChartH;
	public GameObject NW;

	[SerializeField] private Text NumStairs = null;
	[SerializeField] private Text NumPCH01 = null;
	[SerializeField] private Text NumPCH02 = null;
	public GameObject ansSubmitB;

	public int FrameOn = 0;

	void Start(){
		SkillChartStairs.GetComponent<Button> ().enabled = true;
		SkillChartP.GetComponent<Button> ().enabled = true;
		SkillChartC.GetComponent<Button> ().enabled = true;
		SkillChartH.GetComponent<Button> ().enabled = true;
	}

	void Update(){
		if (NumStairs.text != " ") {
			ansSubmitB.SetActive(true);
		}else if( (NumPCH01.text != " ") && (NumPCH02.text != " ") && (int.Parse(NumPCH01.text) >= int.Parse(NumPCH02.text)) && GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 2){
			ansSubmitB.SetActive(true);
		}else if( (NumPCH01.text != " ") && (NumPCH02.text != " ") && (int.Parse(NumPCH01.text) >= int.Parse(NumPCH02.text)) && GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 3){
			ansSubmitB.SetActive(true);
		}else if( (NumPCH01.text != " ") && (NumPCH02.text != " ") && ((int.Parse(NumPCH01.text)+int.Parse(NumPCH02.text)-1) >= int.Parse(NumPCH02.text)) && GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 4){
			ansSubmitB.SetActive(true);
		}else{
			ansSubmitB.SetActive(false);
		}
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
	}
	public void SkillChartDisplay(){
		SkillChartStairs.SetActive(true);
		SkillChartP.SetActive(true);
		SkillChartC.SetActive(true);
		SkillChartH.SetActive(true);
		NW.SetActive(false);
	}
}
