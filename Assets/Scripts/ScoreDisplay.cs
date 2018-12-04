using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	
	public TextMesh scoreText;

	private TextMesh score;
	private bool update;
	private int tempScore;
	private int playerScore;

	// Use this for initialization
	void Start () {
		update = false;
		score = Instantiate(scoreText);
		score.GetComponent<TextMesh>().text = "Score: " + ConsumePlanet.playerScore;
		tempScore = ConsumePlanet.playerScore;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(ConsumePlanet.playerScore);
		if (tempScore < ConsumePlanet.playerScore) {
			update = true;
		}
		if (update) {
			updateScore();
			tempScore = ConsumePlanet.playerScore;
			update = false;
		}
	}
	
	void updateScore() {
		Destroy(score);
		score = Instantiate(scoreText);
		score.GetComponent<TextMesh>().text = "Score: " + ConsumePlanet.playerScore;
	}
}
