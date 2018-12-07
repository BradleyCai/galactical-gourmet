using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeMenu : MonoBehaviour {


	void start() {

	}

	void update() {
		string buttonPressed = EventSystem.current.currentSelectedGameObject.name;

		if (buttonPressed == "StartButton") {
			changeMenu("PlayingScene");
		}
		else if (buttonPressed == "ExitButton") {
			exitGame();
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
}
