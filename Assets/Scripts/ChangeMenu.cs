using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeMenu : MonoBehaviour {

	public static void PlayGame() {
		SceneManager.LoadScene("PlayingScene");
	}

	public static void LoadInstructions() {
		SceneManager.LoadScene("InstructionScene");
	}

	public static void BackScene() {
		SceneManager.LoadScene("StartScene");
	}

	public static void QuitGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void PlayGameMouse() {
		PlayGame();
	}

	public void LoadInstructionsMouse() {
		LoadInstructions();
	}

	public void BackSceneMouse() {
		BackScene();
	}

	public void QuitGameMouse() {
		QuitGame();
	} 

}
