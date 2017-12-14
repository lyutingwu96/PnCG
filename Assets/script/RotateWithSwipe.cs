using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum swipeDirection
{
	None = 0,
	Right = 1,
	Left = 2,
	Up = 4,
	Down = 8,
}

public class RotateWithSwipe : MonoBehaviour {

	private static RotateWithSwipe instance;
	public static RotateWithSwipe Instance{get{return instance;}}

	public swipeDirection Direction{ set; get;}

	private Vector3 touchPosition;
	private float swipeResistanceX = 50.0f;
	private float swipeResistanceY = 100.0f;

	private void Start(){
		instance = this;
	}

	void Update () {

		Direction = swipeDirection.None;

		if (Input.GetMouseButtonDown (0)) {
			touchPosition = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp (0)) {

			Vector2 deltaSwipe = touchPosition - Input.mousePosition;

			if (Mathf.Abs (deltaSwipe.x) > swipeResistanceX ) {
				Direction |= (deltaSwipe.x < 0) ? swipeDirection.Right : swipeDirection.Left;
			}

			if (Mathf.Abs (deltaSwipe.y) > swipeResistanceY) {
				Direction |= (deltaSwipe.y < 0) ? swipeDirection.Up : swipeDirection.Down;
			}
		}
	}
}
