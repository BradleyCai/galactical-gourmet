using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnObject : MonoBehaviour {
	void OnTriggerExit(Collider col) {
		Destroy(col.gameObject);
	}
}
