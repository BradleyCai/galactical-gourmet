using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeMenu : MonoBehaviour {

	public void PlayGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}



/**
	void update() {
		string buttonPressed = EventSystem.current.currentSelectedGameObject.name;

		if (buttonPressed == "StartButton") {
			changeMenu("PlayingScene");
		}
		else if (buttonPressed == "InstructionButton") {
			changeMenu("InstructionScene");
		}
		else if (buttonPressed == "ExitButton") {
			exitGame();
		}
		else if (buttonPressed == "BackButton") {
			changeMenu("StartScene");
		}
	}

	public void changeMenu(string sceneName) {
		Application.LoadLevel(sceneName);
	}

	public void exitGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
**/
}
