using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTrigger : MonoBehaviour {

	Scene currentScene;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(currentScene.name);
		if(currentScene.name == "StartScene") {
			if (Input.GetKeyDown(KeyCode.Alpha1)) // start the game
				ChangeMenu.PlayGame();
			else if (Input.GetKeyDown(KeyCode.Alpha2)) // show instructions
				ChangeMenu.LoadInstructions();
			else if (Input.GetKeyDown(KeyCode.Alpha3)) // quit the program
				ChangeMenu.QuitGame();
			
		}
		if(currentScene.name == "InstructionScene") {
			if (Input.GetKeyDown(KeyCode.Alpha1)) // go back to main menu
				ChangeMenu.BackScene();
		}
	}
}
