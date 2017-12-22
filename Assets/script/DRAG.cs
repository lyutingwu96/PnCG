using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DRAG : MonoBehaviour {
	float OffsetX;
	float OffsetY;

	void Start(){
	}

	void Update(){
	}

	public void BeginDrag(){
		OffsetX = transform.position.x - Input.mousePosition.x;
		OffsetY = transform.position.y - Input.mousePosition.y;
	}

	public void OnDrag(){
		transform.position = new Vector3 (Input.mousePosition.x + OffsetX, Input.mousePosition.y + OffsetY);
	}
}
