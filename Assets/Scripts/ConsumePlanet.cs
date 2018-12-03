using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumePlanet : MonoBehaviour {

    public static int planetCount = 0;

	void OnCollisionStay(Collision col) {
		if(col.gameObject.name == "Planet(Clone)") {
			Destroy(col.gameObject);
			planetCount--;
		}
	}
}
