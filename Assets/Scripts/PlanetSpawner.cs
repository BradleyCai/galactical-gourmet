using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {
	public GameData gameData;
	public Texture[] textures;
	public GameObject planetPrefab;
    public int planetLimit;

	private float spawnDistance = 200f;
	private float scaleLowerRange = 10f;
	private float scaleUpperRange = 50f;

	void Start () {
	}
	
	void Update () {
        if (gameData.planetCount < planetLimit) {
            SpawnSpaceObj(planetPrefab);
            gameData.planetCount++;
        }
	}
	
	void SpawnSpaceObj(GameObject objPrefab) {
		Quaternion spawnDirection = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		float size = Random.Range(scaleLowerRange, scaleUpperRange);
		
		GameObject spaceObj = Instantiate(objPrefab);
		spaceObj.transform.position = GetPosition(spawnDirection, transform.position, spawnDistance);
		spaceObj.transform.rotation = new Quaternion(0, 0, 0, 1);
		spaceObj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		spaceObj.transform.localScale = new Vector3(size, size, size);
		spaceObj.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
	}
	
	Vector3 GetPosition(Quaternion rotation, Vector3 position, float distance) {
		Vector3 direction = rotation * Vector3.forward;
		return position + (direction  * distance);
	}
}
