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
	public float spawnDirectionVariance;
	public float spawnDistance;
	public float spawnDistanceVariance;
	public float spawnSize;
	public float spawnSizeVariance;
	public float spawnCooldown;
	public float spawnCooldownVariance;

	private float time;
	private float nextSpawnCooldown;

	void Start () {
		nextSpawnCooldown = varyValue(spawnCooldown, spawnCooldownVariance);
		for (int i = 0; i < 10; i++) {
			SpawnSpaceObj(planetPrefab, stationary: true);
		}
	}
	
	void Update () {
		time += Time.deltaTime;
		if (time > nextSpawnCooldown) {
			if (gameData.planetCount < planetLimit) {
				SpawnSpaceObj(planetPrefab);
				gameData.planetCount++;
			}
			time = 0;
			nextSpawnCooldown = varyValue(spawnCooldown, spawnCooldownVariance);
		}
	}
	
	void SpawnSpaceObj(GameObject objPrefab, bool stationary=false) {
		float size = varyValue(spawnSize, spawnSizeVariance);
		Quaternion spawnDirection = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		Vector3 velocity;
		
		GameObject spaceObj = Instantiate(objPrefab);
		spaceObj.transform.position = GetPosition(
			spawnDirection, transform.position, varyValue(spawnDistance, spawnDistanceVariance));
		spaceObj.transform.rotation = new Quaternion(0, 0, 0, 1);
		if (!stationary) {
			velocity = -Vector3.Normalize(spaceObj.transform.position - transform.position) * spawnSpeed;
			velocity.x += Random.Range(-spawnDirectionVariance, spawnSpeedVariance);
			velocity.y += Random.Range(-spawnDirectionVariance, spawnSpeedVariance);
			velocity.z += Random.Range(-spawnDirectionVariance, spawnSpeedVariance);
		}
		else {
			velocity = new Vector3(0, 0, 0);
		}
		spaceObj.GetComponent<Rigidbody>().velocity = velocity;
		spaceObj.transform.localScale = new Vector3(size, size, size);
		spaceObj.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
	}
	
	Vector3 GetPosition(Quaternion rotation, Vector3 position, float distance) {
		Vector3 direction = rotation * Vector3.forward;
		return position + (direction  * distance);
	}

	float varyValue(float value, float variance) {
		return value + Random.Range(-variance, variance);
	}
}
