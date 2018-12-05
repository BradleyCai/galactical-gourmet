using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private MouseLook mouseLook;

	void Start () {
		mouseLook = GetComponent<MouseLook>();
		mouseLook.enabled = false;
	}
	
	void Update () {

		/** 
			NOT TO BE PART OF FINAL PROJECT

			The "M" key is currently set to toggle mouse control on
			or off. It's used to debug the game without a vr headset.
		**/
		if (Input.GetKeyDown(KeyCode.M)) {
			mouseLook.enabled = !mouseLook.enabled;
		}
	}
}
