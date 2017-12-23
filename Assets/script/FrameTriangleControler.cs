using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameTriangleControler : MonoBehaviour {
	[SerializeField] private Image NumStairsTri = null;
	[SerializeField] private Image NumPCH01Tri = null;
	[SerializeField] private Image NumPCH02Tri = null;
	[SerializeField] private Image StairsTri = null;
	[SerializeField] private Image PCHTri = null;
	[SerializeField] private Image FP201Tri = null;
	[SerializeField] private Image FP202Tri = null;

	public void NumStairsTriOn(){
		NumStairsTri.enabled = true;
		NumPCH01Tri.enabled = false;
		NumPCH02Tri.enabled = false;
		StairsTri.enabled = false;
		PCHTri.enabled = false;
		FP201Tri.enabled = false;
		FP202Tri.enabled = false;
	}
	public void NumPCH01TriOn(){
		NumStairsTri.enabled = false;
		NumPCH01Tri.enabled = true;
		NumPCH02Tri.enabled = false;
		StairsTri.enabled = false;
		PCHTri.enabled = false;
		FP201Tri.enabled = false;
		FP202Tri.enabled = false;
	}
	public void NumPCH02TriOn(){
		NumStairsTri.enabled = false;
		NumPCH01Tri.enabled = false;
		NumPCH02Tri.enabled = true;
		StairsTri.enabled = false;
		PCHTri.enabled = false;
		FP201Tri.enabled = false;
		FP202Tri.enabled = false;
	}
	public void StairsTriOn(){
		NumStairsTri.enabled = false;
		NumPCH01Tri.enabled = false;
		NumPCH02Tri.enabled = false;
		StairsTri.enabled = true;
		PCHTri.enabled = false;
		FP201Tri.enabled = false;
		FP202Tri.enabled = false;
	}
	public void PCHTriOn(){
		NumStairsTri.enabled = false;
		NumPCH01Tri.enabled = false;
		NumPCH02Tri.enabled = false;
		StairsTri.enabled = false;
		PCHTri.enabled = true;
		FP201Tri.enabled = false;
		FP202Tri.enabled = false;
	}
	public void FP01TriOn(){
		NumStairsTri.enabled = false;
		NumPCH01Tri.enabled = false;
		NumPCH02Tri.enabled = false;
		StairsTri.enabled = false;
		PCHTri.enabled = false;
		FP201Tri.enabled = true;
		FP202Tri.enabled = false;
	}
	public void FP02TriOn(){
		NumStairsTri.enabled = false;
		NumPCH01Tri.enabled = false;
		NumPCH02Tri.enabled = false;
		StairsTri.enabled = false;
		PCHTri.enabled = false;
		FP201Tri.enabled = false;
		FP202Tri.enabled = true;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
