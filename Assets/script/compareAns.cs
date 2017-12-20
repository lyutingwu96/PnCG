using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using Fungus;

public class compareAns : MonoBehaviour {

	public Flowchart flowchart;
	public GameObject Calculator;
	public GameObject Answers;

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
	public GameObject ansSubmitB;
	public GameObject QuestionBG;

	[SerializeField] private Text NumStairsT = null;
	[SerializeField] private Text NumPCH01T = null;
	[SerializeField] private Text NumPCH02T = null;
	[SerializeField] private Text NumFPT = null;
	[SerializeField] private Text NumFP201T = null;
	[SerializeField] private Text NumFP202T = null;
	[SerializeField] private Text Result = null;
	[SerializeField] private Text ResultScore = null;
	[SerializeField] private Text question = null;

	[SerializeField] private Image NumStairsTri = null;
	[SerializeField] private Image NumPCH01Tri = null;
	[SerializeField] private Image NumPCH02Tri = null;
	[SerializeField] private Image StairsTri = null;
	[SerializeField] private Image PCHTri = null;
	[SerializeField] private Image FP201Tri = null;
	[SerializeField] private Image FP202Tri = null;

	private int currentProblem;
	private bool firstProblem;

	private int currentFunc;

	private int currentN;
	private int currentM;
	private int currentResult;

	public int ansFunc;
	public int ansN;
	public int ansM;
	public int ansResult;
	public int feedbackNum;

	private bool inExam;
	private bool examLast;
	public float examScore;



	private string jsonString;
	private JsonData jsonData;


	void OnEnable () {
		getFlowchartNums ();
		searchAnswer ();
	}


	void getFlowchartNums(){
		firstProblem = flowchart.GetBooleanVariable ("FirstProblem");
		currentProblem = flowchart.GetIntegerVariable ("CurrentProblem");
		inExam = flowchart.GetBooleanVariable ("InExam");
		examLast = flowchart.GetBooleanVariable ("ExamLast");
		examScore = flowchart.GetFloatVariable ("ExamScore");
	}

	public void searchAnswer(){
		/*//string myPath = "/Data/myJson.json";
		string myPath = "/StreamingAssets/myJson.json";
		jsonString = File.ReadAllText (Application.dataPath + myPath);//(1)
		jsonData = JsonMapper.ToObject (jsonString);//(2)

		ansFunc = (int) jsonData ["ans"] [currentProblem] ["Func"];
		ansN = (int)jsonData ["ans"] [currentProblem] ["N"];
		ansM = (int)jsonData ["ans"] [currentProblem] ["M"];
		ansResult = (int)jsonData ["ans"] [currentProblem] ["Result"];*/

		ansFunc = Answers.GetComponent<AnswerSetup> ().answerList [currentProblem].Func;
		ansN = Answers.GetComponent<AnswerSetup> ().answerList [currentProblem].N;
		ansM = Answers.GetComponent<AnswerSetup> ().answerList [currentProblem].M;
		ansResult = Answers.GetComponent<AnswerSetup> ().answerList [currentProblem].Result;

		Debug.Log ("ansFunc = " + ansFunc);
		Debug.Log ("ansN = " + ansN);
		Debug.Log ("ansM = " + ansM);
		Debug.Log ("ansResult = " + ansResult);
	}

	void setFBNum(){
		flowchart.SetIntegerVariable ("FBNum",feedbackNum);
		int FBNumNow = flowchart.GetIntegerVariable ("FBNum");
		Debug.Log ("FBNumNow = " + FBNumNow);
	}
	void setExamScore(){
		flowchart.SetFloatVariable ("ExamScore",examScore);
	}


	void callFlowchartBlock(){
		bool inEXAMornot = flowchart.GetBooleanVariable ("InExam");
		if (inEXAMornot == true) {
			int nowproblem = flowchart.GetIntegerVariable ("CurrentProblem");
			nowproblem = nowproblem - 4;
			if (nowproblem == 9) {
				Block target = flowchart.FindBlock ("SCORE");
				flowchart.ExecuteBlock (target);
			} else {
				string targetname = "Q" + nowproblem;
				Block target = flowchart.FindBlock (targetname);
				flowchart.ExecuteBlock (target);
			}

		} else {
			int ChapNum=flowchart.GetIntegerVariable ("CurrentChap");
			int ProblemNum=flowchart.GetIntegerVariable ("ChapProblem");
			string targetname = "ansFeedback" + ChapNum + "-" + ProblemNum;
			Block target = flowchart.FindBlock (targetname);
			flowchart.ExecuteBlock (target);
		}
	}

	void compareAnswerFP(){
		if (currentResult == ansResult) {
			feedbackNum = 4;
			if (inExam) {
				examScore += 1;
				setExamScore ();
			}
		} else {
			feedbackNum = 2;
		}
		setFBNum ();
		Debug.Log (feedbackNum);
		callFlowchartBlock ();

	}

	void compareAnswerFP2(){
		if ((currentN == ansN)&&(currentM == ansM)) {
			feedbackNum = 4;
			if (inExam) {
				examScore += 1;
				setExamScore ();
			}
		} else {
			feedbackNum = 2;
		}
		setFBNum ();
		Debug.Log (feedbackNum);
		callFlowchartBlock ();

	}

	void compareAnswerStairs(){
		if (currentFunc != ansFunc) {
			feedbackNum = 1;
		} else if ((currentFunc == ansFunc) && (currentN != ansN)) {
			feedbackNum = 2;
		} else if ((currentFunc == ansFunc) && (currentResult == ansResult)) {
			feedbackNum = 4;
			if (inExam) {
				examScore += 1;
				setExamScore ();
			}
		}
		setFBNum ();
		Debug.Log (feedbackNum);
		callFlowchartBlock ();
	}

	void compareAnswerPCH(){
		if (currentFunc != ansFunc) {
			feedbackNum = 1;
		} else if ((currentFunc == ansFunc) && (currentN != ansN)) {
			feedbackNum = 2;
		}else if((currentFunc == ansFunc) && (currentN == ansN) && (currentM != ansM)){
			feedbackNum = 3;
		}else if((currentFunc == ansFunc) && (currentN == ansN) && (currentM != ansM) && (currentResult == ansResult)) {
			feedbackNum = 3;
		}else if ((currentFunc == ansFunc) && (currentN == ansN) && (currentM == ansM) && (currentResult == ansResult)) {
			feedbackNum = 4;
			if (inExam) {
				examScore += 1;
				setExamScore ();
			}
		}
		setFBNum ();
		Debug.Log (feedbackNum);
		callFlowchartBlock ();
	}


	public void countResult(){
		currentFunc = GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn;
		if (firstProblem) {
			if (currentProblem == 2) {
				currentN = int.Parse (NumFP201T.text);
				currentM = int.Parse (NumFP202T.text);
				compareAnswerFP2 ();
			} else {
				currentResult = int.Parse (NumFPT.text);
				compareAnswerFP ();
			}
		} else {

			if (currentFunc == 1) {
			
				currentN = int.Parse (NumStairsT.text);	
				currentM = -1;
				currentResult = countStairs (currentN);

				compareAnswerStairs ();
				//PrintStairs (currentResult, currentN);

			} else if (currentFunc == 2) {
			
				currentN = int.Parse (NumPCH01T.text);
				currentM = int.Parse (NumPCH02T.text);
				currentResult = countP (currentN, currentM);

				compareAnswerPCH ();
				//PrintP (currentResult,currentN , currentM);

			} else if (currentFunc == 3) {
			
				currentN = int.Parse (NumPCH01T.text);
				currentM = int.Parse (NumPCH02T.text);
				currentResult = countC (currentN, currentM);

				compareAnswerPCH ();
				//PrintC (currentResult, currentN, currentM);

			} else if (currentFunc == 4) {
			
				currentN = int.Parse (NumPCH01T.text);
				currentM = int.Parse (NumPCH02T.text);
				currentResult = countH (currentN, currentM);

				compareAnswerPCH ();
				//PrintH (currentResult, currentN, currentM, currentN+currentM-1);

			}
		}


		SkillFrameStairs.SetActive (false);
		SkillFramePCH.SetActive (false);
		SkillStairs.SetActive (false);
		SkillP.SetActive (false);
		SkillC.SetActive (false);
		SkillH.SetActive (false);
		NumberFrameStairs.SetActive (false);
		NumberFramePCH1.SetActive (false);
		NumberFramePCH2.SetActive (false);
		NumberFrameFP.SetActive (false);
		NumberFrameFP201.SetActive (false);
		NumberFrameFP202.SetActive (false);

		NW.transform.Rotate (new Vector3 (NW.transform.rotation.x, NW.transform.rotation.y, -NW.transform.eulerAngles.z));
		NW.SetActive (false);

		SkillChartStairs.SetActive (false);
		SkillChartP.SetActive (false);
		SkillChartC.SetActive (false);
		SkillChartH.SetActive (false);

		QuestionBG.SetActive (false);

		NumStairsT.text = " ";
		NumPCH01T.text = " ";
		NumPCH02T.text = " ";
		NumFPT.text = " ";
		NumFP201T.text = " ";
		NumFP202T.text = " ";
		question.text = " ";
		NumStairsTri.enabled = false;
		NumPCH01Tri.enabled = false;
		NumPCH02Tri.enabled = false;
		StairsTri.enabled = false;
		PCHTri.enabled = false;
		FP201Tri.enabled = false;
		FP202Tri.enabled = false;

		if (inExam && !examLast) {
			Calculator.GetComponent<CalculatorManager> ().CalculatorOff();
		}

		//SkillChartStairs.GetComponent<Button> ().enabled = false;
		//SkillChartP.GetComponent<Button> ().enabled = false;
		//SkillChartC.GetComponent<Button> ().enabled = false;
		//SkillChartH.GetComponent<Button> ().enabled = false;


	}

	int countStairs(int n){
		if (n == 0) {
			return 1;
		} else {
			int ans = n;
			for (int i = 1; i < n; i++) {
				ans *= i;
			}

			return ans;
		}
	}
	int countP(int n, int m){
		int ans = 0;
		int tmp = n - m;
		ans = countStairs (n) / countStairs (tmp);

		return ans;
	}
	int countC(int n, int m){
		int ans = 0;
		int tmp = n - m;
		ans = countStairs (n) / (countStairs (tmp) * countStairs(m));
		return ans;
	}
	int countH(int n, int m){
		int ans = 0;
		ans = countC (n + m - 1, m);
		return ans;
	}

	void PrintStairs(int result, int n){
		string p = "";

		p= n+"!\n= ";

		if (n == 0) {
			p += "1";
		} else {

			for (int i = n; i > 1; i--) {
				p += i + " * ";
			}
			p += "1\n= " + result;
		}
		Result.text = p;
	}

	void PrintP(int result, int n, int m){
		string p = "";
		p = "P(" + n + ", " + m + ")\n= " + n + "! / (" + n + " - " + m + ")!\n= " + result;
		Result.text = p;
	}
	void PrintC(int result, int n, int m){
		string p = "";
		p = "C(" + n + ", " + m + ")\n= " + n + "! / (" + m + "! (" + n + " - " + m + ")! )\n= " + result;
		Result.text = p;
	}
	void PrintH(int result, int n, int m, int cn){
		string p = "";
		p = "H(" + n + ", " + m + ")\n= C(" + n + " + " + m + " - 1, " + m + ")= " + "C(" + cn + ", " + m + ")\n= " + cn + "! / (" + m + "! (" + cn + " - " + m + ")! )\n= " + result;
		Result.text = p;
	}
	public void PrintExamScore(){
		string p = "";
		float score = examScore;
		score = score * 12.5f;
		p = "Result Score : " + score;
		ResultScore.text = p;
	}

	public void ResultExamScoreReset(){
		ResultScore.text = " ";
	}
}
