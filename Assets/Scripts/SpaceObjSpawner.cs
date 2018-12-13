using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObjSpawner : MonoBehaviour {
	public GameData gameData;
	public Texture[] textures;
	public GameObject spaceObjPrefab;
	public int startSpawnCount; // Spawns this many objects before the game starts
	public float startSpawnCountVariance;
	public float spawnSpeed;
	public float spawnSpeedVariance;
	public float spawnDirectionVariance;
	public bool distIsPlayerBased; // Will scale "spawnDistance" based on player size
	public float spawnDistance;
	public float spawnDistanceVariance;
	public bool sizeIsPlayerBased; // Will override the "spawnSize" to be based on player's size
	public float spawnSize;
	public float spawnSizeVariance;
	public bool doesntRespawn; // Makes it so this spawner only spawns at the beginning
	public float spawnCooldown;
	public float spawnCooldownVariance;
	public int[] texturesUsed;

	private float time;
	private float nextSpawnCooldown;

	void Start () {
		nextSpawnCooldown = varyValue(spawnCooldown, spawnCooldownVariance);
		for (int i = 0; i < varyValue(startSpawnCount, startSpawnCountVariance); i++) {
			SpawnSpaceObj(spaceObjPrefab);
		}
	}
	
	void Update () {
		time += Time.deltaTime;
		if (!doesntRespawn && time > nextSpawnCooldown) {
			if (gameData.planetCount < gameData.planetLimit) {
				SpawnSpaceObj(spaceObjPrefab);
				gameData.planetCount++;
			}
			time = 0;
			nextSpawnCooldown = varyValue(spawnCooldown, spawnCooldownVariance);
		}
	}
	
	void SpawnSpaceObj(GameObject objPrefab) {
		Quaternion spawnDirection = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		float size = varyValue(sizeIsPlayerBased ? gameData.playerSize + spawnSize : spawnSize, spawnSizeVariance);
		float distance = varyValue(distIsPlayerBased ? spawnDistance * gameData.playerSize / 10 : spawnDistance, spawnSizeVariance);
		Vector3 velocity;
		
		GameObject spaceObj = Instantiate(objPrefab);

		spaceObj.transform.localScale = new Vector3(size, size, size);
		spaceObj.transform.position = GetPosition(spawnDirection, transform.position, distance);
		spaceObj.transform.rotation = new Quaternion(0, 0, 0, 1);

		velocity = Vector3.Normalize(transform.position - spaceObj.transform.position) * spawnSpeed;
		velocity.x += Random.Range(-spawnDirectionVariance, spawnSpeedVariance);
		velocity.y += Random.Range(-spawnDirectionVariance, spawnSpeedVariance);
		velocity.z += Random.Range(-spawnDirectionVariance, spawnSpeedVariance);
		spaceObj.GetComponent<Rigidbody>().velocity = velocity;

		spaceObj.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
	}
	
	Vector3 GetPosition(Quaternion rotation, Vector3 position, float distance) {
		Vector3 direction = rotation * Vector3.forward;
		return position + (direction  * distance);
	}

	/*
	 * Creates a random number that varies by `variance` percent from `value`
	 * More specifically a random number between: [value - (value * variance), value + (value * variance)]
	 *
	 */
	float varyValue(float value, float variance) {
		return value + Random.Range(-value * variance, value * variance);
	}
}
