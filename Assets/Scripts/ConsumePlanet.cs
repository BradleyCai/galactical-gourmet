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
			float planetSize = col.gameObject.transform.lossyScale.x;
			float scaleAmount = Mathf.Pow(planetSize / gameData.playerSize, 2) + 1;
			Vector3 handOrt = leftHand.transform.position - parent.transform.position;

			Destroy(col.gameObject);
			gameData.planetCount--;
			gameData.playerScore++;
			if (!gameData.isDebugging)
				controller.transform.position -= handOrt * 2 + handOrt * gameData.sizeGrowth;
			else
				controller.transform.position -= (leftHand.transform.forward * 0.8f) + (leftHand.transform.forward * gameData.sizeGrowth);
			gameData.playerSize *= scaleAmount;

			for (int i = 0; i < cameras.Length; i++) {
				cameras[i].camera.farClipPlane *= scaleAmount;
			}
		}
	}
}
