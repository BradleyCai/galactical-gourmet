using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	
	public TextMesh scoreText;

	private int playerScore;

	// Use this for initialization
	void Start () {
		playerScore = ConsumePlanet.playerScore;
	}
	
	// Update is called once per frame
	void Update () {
		TextMesh score = Instantiate(scoreText);
		score.GetComponent<TextMesh>().text = "Score: " + playerScore;
	}
	
}
