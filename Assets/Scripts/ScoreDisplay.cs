using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	
	public TextMesh scoreText;

	private int playerScore;

	// Use this for initialization
	void Start () {	
		scoreText.GetComponent<TextMesh>().text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(ConsumePlanet.playerScore);
		scoreText.GetComponent<TextMesh>().text = "Score: " + ConsumePlanet.playerScore;
	}
	
}
