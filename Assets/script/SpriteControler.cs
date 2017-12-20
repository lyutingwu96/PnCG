using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControler : MonoBehaviour {
	public GameObject sprite1 = null;
	public GameObject sprite2 = null;
	public GameObject sprite3 = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spriteOn(){
		sprite1.SetActive (true);
		sprite2.SetActive (true);
		sprite3.SetActive (true);
	}
}
