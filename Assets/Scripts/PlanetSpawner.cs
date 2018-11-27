using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {
	public GameObject player;
	public Texture[] textures;
	public GameObject planetPrefab;
	public Material planetMaterial;

	private float spawnDistance = 200f;
	private float scaleLowerRange = 10f;
	private float scaleUpperRange = 50f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		SpawnPlanet();
	}
	
	void SpawnPlanet() {
		// Vector3 posOffsetAmount = new Vector3(Random.Range(-posOffset, posOffset), Random.Range(-posOffset, posOffset), Random.Range(-posOffset, posOffset));
		Quaternion spawnDirection = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		float size = Random.Range(scaleLowerRange, scaleUpperRange);
		
		GameObject planet = Instantiate(planetPrefab);
		planet.transform.position = GetPosition(spawnDirection, player.transform.position, spawnDistance);
		planet.transform.rotation = new Quaternion(0, 0, 0, 1);
		planet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		planet.transform.localScale = new Vector3(size, size, size);
		planet.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
	}
	
	Vector3 GetPosition(Quaternion rotation, Vector3 position, float distance) {
		Vector3 direction = rotation * Vector3.forward;
		return position + (direction  * distance);
	}
}
