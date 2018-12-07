using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameData gameData;
	public GameObject scoreText;
	public GameObject playerObject;
	private MouseLook mouseLook;

	void Start () {
        mouseLook = GetComponent<MouseLook>();
        mouseLook.enabled = false;
        scoreText.SetActive(false);
	}
	
	void Update () {
		/** 
			Key "F10":
				Toggles debug mode
		**/
		if (Input.GetKeyDown(KeyCode.F10)) {
            gameData.isDebugging = !gameData.isDebugging;
            mouseLook.enabled = !mouseLook.enabled;
            scoreText.SetActive(!scoreText.activeSelf);
            playerObject.transform.position -= new Vector3(0, 1, 0);
		}
	}
}
