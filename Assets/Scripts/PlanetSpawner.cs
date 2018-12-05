using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {
	public GameData gameData;
	public Texture[] textures;
	public GameObject planetPrefab;
    public int planetLimit;
	public float spawnSpeed;
	public float spawnSpeedVariance;
	public float spawnDistance;
	public float spawnDistanceVariance;
	public float spawnSize;
	public float spawnSizeVariance;

	void Start () {
	}
	
	void Update () {
        if (gameData.planetCount < planetLimit) {
            SpawnSpaceObj(planetPrefab);
            gameData.planetCount++;
        }
	}
	
	void SpawnSpaceObj(GameObject objPrefab) {
		float size = spawnSize + Random.Range(-spawnSizeVariance, spawnSizeVariance);
		Quaternion spawnDirection = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		Vector3 velocity;
		
		GameObject spaceObj = Instantiate(objPrefab);
		spaceObj.transform.position = GetPosition(
			spawnDirection, transform.position, spawnDistance + Random.Range(-spawnDistanceVariance, spawnDistanceVariance));
		spaceObj.transform.rotation = new Quaternion(0, 0, 0, 1);
		velocity = -Vector3.Normalize(spaceObj.transform.position) * spawnSpeed;
		velocity.x += Random.Range(-spawnSpeedVariance, spawnSpeedVariance);
		velocity.y += Random.Range(-spawnSpeedVariance, spawnSpeedVariance);
		velocity.z += Random.Range(-spawnSpeedVariance, spawnSpeedVariance);
		spaceObj.GetComponent<Rigidbody>().velocity = velocity;
		spaceObj.transform.localScale = new Vector3(size, size, size);
		spaceObj.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
	}
	
	Vector3 GetPosition(Quaternion rotation, Vector3 position, float distance) {
		Vector3 direction = rotation * Vector3.forward;
		return position + (direction  * distance);
	}
}
