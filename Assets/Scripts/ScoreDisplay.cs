using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	public GameData gameData;

	// Use this for initialization
	void Start () {	
		GetComponent<TextMesh>().text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = "Score: " + gameData.playerScore;
	}
	
}
