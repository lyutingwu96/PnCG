using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countAns : MonoBehaviour {

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
	public GameObject ansBUt;

	[SerializeField] private Text NumStairsT = null;
	[SerializeField] private Text NumPCH01T = null;
	[SerializeField] private Text NumPCH02T = null;
	[SerializeField] private Text Result = null;

	public void countResult(){
		

		int result = 0;

		Debug.Log (GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn);
		if (GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 1) {
			int n = int.Parse (NumStairsT.text);	
			result = countStairs (n);
			PrintStairs (result, n);
		} else if (GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 2) {
			int n = int.Parse (NumPCH01T.text);
			int m = int.Parse (NumPCH02T.text);
			result = countP (n, m);
			PrintP (result,n , m);
		} else if (GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 3) {
			int n = int.Parse (NumPCH01T.text);
			int m = int.Parse (NumPCH02T.text);
			result = countC (n, m);
			PrintC (result, n, m);
		}
		else if (GameObject.Find ("Selected").GetComponent<calculator> ().FrameOn == 4) {
			int n = int.Parse (NumPCH01T.text);
			int m = int.Parse (NumPCH02T.text);
			result = countH (n, m);
			PrintH (result, n, m, n+m-1);
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
		NW.SetActive (false);

		SkillChartStairs.SetActive (true);
		SkillChartP.SetActive (true);
		SkillChartC.SetActive (true);
		SkillChartH.SetActive (true);

		SkillChartStairs.GetComponent<Button> ().enabled = false;
		SkillChartP.GetComponent<Button> ().enabled = false;
		SkillChartC.GetComponent<Button> ().enabled = false;
		SkillChartH.GetComponent<Button> ().enabled = false;

		ansBUt.GetComponent<Image> ().enabled = false;
		ansBUt.GetComponent<Button> ().enabled = false;

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
		ans = countStairs (n) / countStairs (n - m);
		return ans;
	}
	int countC(int n, int m){
		int ans = 0;
		ans = countStairs (n) / (countStairs (n - m) * countStairs(m));
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
}
