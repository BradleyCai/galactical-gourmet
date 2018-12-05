using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumePlanet : MonoBehaviour {
	public GameData gameData;

	void OnCollisionStay(Collision col) {
		if(col.gameObject.tag == "Planet") {
			Destroy(col.gameObject);
			gameData.planetCount--;
			gameData.playerScore++;
		}
	}
}
