using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DRAG : MonoBehaviour {
	float baseAngle;
	float OffsetX;
	float OffsetY;

	void Start(){
	}

	void Update(){
	}

	public void BeginDrag(){
		OffsetX = transform.position.x - Input.mousePosition.x;
		OffsetY = transform.position.y - Input.mousePosition.y;
		baseAngle=Mathf.Atan2(OffsetY,OffsetX)*Mathf.Rad2Deg;
		baseAngle-=Mathf.Atan2(transform.right.y,transform.right.x)*Mathf.Rad2Deg;

	}

	public void OnDrag(){
		//transform.position = new Vector3 (Input.mousePosition.x + OffsetX, Input.mousePosition.y + OffsetY);
		OffsetX = -(transform.position.x - Input.mousePosition.x);
		OffsetY = -(transform.position.y - Input.mousePosition.y);
		float ang = Mathf.Atan2 (OffsetY,OffsetX) * Mathf.Rad2Deg - baseAngle;
		transform.rotation = Quaternion.AngleAxis (ang, Vector3.forward);
	}
}