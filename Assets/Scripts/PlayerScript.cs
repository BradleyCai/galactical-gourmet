using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
		moveSpeed = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		/** NOT TO BE PART OF FINAL PROJECT **/
		// Basic testing for player movement
		GetComponent<Rigidbody>().transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,
													  0,
													  moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
	}
}
