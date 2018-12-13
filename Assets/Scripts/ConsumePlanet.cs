using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumePlanet : MonoBehaviour {
	public GameData gameData;
	public GameObject leftHand;
    public GameObject parent;
	public GameObject player;
	public GameObject controller;
	public GameObject[] cameras;

	void OnCollisionStay(Collision col) {
		if(col.gameObject.tag == "Planet") {
			Destroy(col.gameObject);
			gameData.planetCount--;

			if (col.gameObject.transform.lossyScale.x > gameData.playerSize) {
				if (gameData.playerSize < gameData.sizeGrowth) {
					// gameover
				}

				if (gameData.playerScore > 0)
					gameData.playerScore--;

				gameData.playerSize -= gameData.sizeGrowth;
			}
			else {
				float planetSize = col.gameObject.transform.lossyScale.x;
				float scaleAmount = Mathf.Pow(planetSize / gameData.playerSize, 2) + 1;
				Vector3 handOrt = leftHand.transform.position - parent.transform.position;

				gameData.playerScore++;
				gameData.playerSize *= scaleAmount;

				for (int i = 0; i < cameras.Length; i++) {
					cameras[i].GetComponent<Camera>().farClipPlane *= scaleAmount;
				}
			}
		}
	}
}
