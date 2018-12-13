using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeMenu : MonoBehaviour {

	public static void StartScene() {
		SceneManager.LoadScene("StartScene");
	}

	public static void InstructionScene() {
		SceneManager.LoadScene("InstructionScene");
	}

	public static void PlayScene() {
		SceneManager.LoadScene("PlayingScene");
	}

	public static void GameOverScene() {
		SceneManager.LoadScene("GameOverScene");
	}

	public static void QuitGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}


}
