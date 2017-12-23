using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSetup : MonoBehaviour {

	public class Answer
	{
		public int Func;
		public int N;
		public int M;
		public int Result;
		public int problemNum;
		public int Exam;

		public Answer(int func, int n, int m, int result, int num,int exam)
		{
			Func = func;
			N = n;
			M = m;
			Result = result;
			problemNum = num;
			Exam = exam;
		}
	}

	public List<Answer> answerList;

	// Use this for initialization
	void Start () {
	
		answerList = new List<Answer> ();

		answerList.Add (new Answer (-1, -1, -1, 6, 0,-1));
		answerList.Add (new Answer (1, 5, -1, 120, 1,-1));
		answerList.Add (new Answer (-1, 1, 2, -1, 2,-1));
		answerList.Add (new Answer (2, 5, 3, 60, 3,-1));
		answerList.Add (new Answer (-1, -1, -1, 3, 4,-1));
		answerList.Add (new Answer (3, 9, 3, 84, 5,-1));

		//exam
		answerList.Add (new Answer (1, 3, -1, 6, 6,1));
		answerList.Add (new Answer (1, 5, -1, 120, 7,2));
		answerList.Add (new Answer (3, 4, 2, 6, 8,3));
		answerList.Add (new Answer (2, 9, 4, 3024, 9,4));
		answerList.Add (new Answer (3, 7, 3, 35, 10,5));
		answerList.Add (new Answer (3, 8, 2, 28, 11,6));
		answerList.Add (new Answer (3, 9, 3, 84, 12,7));
		answerList.Add (new Answer (2, 6, 4, 360, 13,8));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
