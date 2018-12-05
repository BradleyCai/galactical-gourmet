using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {
	public GameData gameData;
	public Texture[] textures;
	public GameObject planetPrefab;
    public int planetLimit;
	public float planetSpeed;
	public float planetSpeedVariance;
	public float spawnDistance;
	public float spawnDistanceVariance;
	public float planetSize;
	public float planetSizeVariance;

	void Start () {
	}
	
	void Update () {
        if (gameData.planetCount < planetLimit) {
            SpawnSpaceObj(planetPrefab);
            gameData.planetCount++;
        }
	}
	
	void SpawnSpaceObj(GameObject objPrefab) {
		float size = planetSize + Random.Range(-planetSizeVariance, planetSizeVariance);
		Quaternion spawnDirection = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		Vector3 velocity;
		
		GameObject spaceObj = Instantiate(objPrefab);
		spaceObj.transform.position = GetPosition(
			spawnDirection, transform.position, spawnDistance + Random.Range(-spawnDistanceVariance, spawnDistanceVariance));
		spaceObj.transform.rotation = new Quaternion(0, 0, 0, 1);
		velocity = -Vector3.Normalize(spaceObj.transform.position) * planetSpeed;
		velocity.x += Random.Range(-planetSpeedVariance, planetSpeedVariance);
		velocity.y += Random.Range(-planetSpeedVariance, planetSpeedVariance);
		velocity.z += Random.Range(-planetSpeedVariance, planetSpeedVariance);
		spaceObj.GetComponent<Rigidbody>().velocity = velocity;
		spaceObj.transform.localScale = new Vector3(size, size, size);
		spaceObj.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
	}
	
	Vector3 GetPosition(Quaternion rotation, Vector3 position, float distance) {
		Vector3 direction = rotation * Vector3.forward;
		return position + (direction  * distance);
	}
}
