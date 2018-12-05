using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject scoreText;
	private MouseLook mouseLook;

	void Start () {
		mouseLook = GetComponent<MouseLook>();
		mouseLook.enabled = false;
		scoreText.SetActive(false);
	}
	
	void Update () {
		/** 
			DEBUG CODES

			Key "M":
				Toggles mouse camera movement
			Key "T":
				Toggles score text display
		**/
		if (Input.GetKeyDown(KeyCode.M)) {
			mouseLook.enabled = !mouseLook.enabled;
		}
		else if (Input.GetKeyDown(KeyCode.T)) {
			scoreText.SetActive(!scoreText.activeSelf);
		}
	}
}
