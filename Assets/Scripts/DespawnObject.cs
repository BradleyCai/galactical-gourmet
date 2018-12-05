using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObject : MonoBehaviour {
	public GameData gameData;

	void OnTriggerExit(Collider col) {
		Destroy(col.gameObject);
		gameData.planetCount--;
	}
}
