using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {

	public GameObject player;
	private float distFromPlayer = 10f;
	PlanetPooler planetPooler;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		planetPooler = PlanetPooler.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		// makes sure the planets don't spawn on top of the player
		Vector3 spawnPos = new Vector3(player.transform.position.x + distFromPlayer, 
									   player.transform.position.y + distFromPlayer, 
									   player.transform.position.z + distFromPlayer);
		PlanetPooler.Instance.SpawnFromPool("Planet", spawnPos, Quaternion.identity);
	}
}
