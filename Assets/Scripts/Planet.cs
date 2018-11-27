using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour, IPooledObject {

	public float upForce = 15f;
	public float sideForce = 20f;

	public void OnObjectSpawn () {
		
		// Random Initial Velocity
		float xForce = Random.Range(-sideForce, sideForce);
		float yForce = Random.Range(-upForce / 2f, upForce);
		float zForce = Random.Range(-sideForce, sideForce);
		Vector3 force = new Vector3(xForce, yForce, zForce);
		GetComponent<Rigidbody>().velocity = force;

		// Random Spawn Position (relative to the user)
		GetComponent<Rigidbody>().transform.position += new Vector3(Random.Range(-1000.0f, 1000.0f), 
															  	 	Random.Range(-1000.0f, 1000.0f), 
															   		Random.Range(-1000.0f, 1000.0f));
		
		// Random Spawn Size
		float randSize = Random.Range(0f, 200.0f);
		GetComponent<Rigidbody>().transform.localScale = new Vector3(randSize, randSize, randSize);

	}


}
