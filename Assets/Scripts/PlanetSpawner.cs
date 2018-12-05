using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {
	public GameData gameData;
	public Texture[] textures;
	public GameObject planetPrefab;
	public int startSpawnCount;
	public int startSpawnCountVariance;
	public float spawnSpeed;
	public float spawnSpeedVariance;
	public float spawnDirectionVariance;
	public float spawnDistance;
	public float spawnDistanceVariance;
	public bool sizeIsPlayerBased; // Will override the "spawnSize" to be based on player's size
	public float spawnSize;
	public float spawnSizeVariance;
	public bool infiniteCooldown; // Will override spawnCooldown to be infinite
	public float spawnCooldown;
	public float spawnCooldownVariance;

	private float time;
	private float nextSpawnCooldown;

	void Start () {
		nextSpawnCooldown = varyValue(spawnCooldown, spawnCooldownVariance);
		for (int i = 0; i < varyValue(startSpawnCount, startSpawnCountVariance); i++) {
			SpawnSpaceObj(planetPrefab);
		}
	}
	
	void Update () {
		time += Time.deltaTime;
		if (!infiniteCooldown && time > nextSpawnCooldown) {
			if (gameData.planetCount < gameData.planetLimit) {
				SpawnSpaceObj(planetPrefab);
				gameData.planetCount++;
			}
			time = 0;
			nextSpawnCooldown = varyValue(spawnCooldown, spawnCooldownVariance);
		}
	}
	
	void SpawnSpaceObj(GameObject objPrefab) {
		Quaternion spawnDirection = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
		float size = varyValue((sizeIsPlayerBased) ? gameData.playerSize : spawnSize, spawnSizeVariance);
		Vector3 velocity;
		
		GameObject spaceObj = Instantiate(objPrefab);
		spaceObj.transform.localScale = new Vector3(size, size, size);
		spaceObj.transform.position = GetPosition(
			spawnDirection, transform.position, varyValue(spawnDistance, spawnDistanceVariance));
		spaceObj.transform.rotation = new Quaternion(0, 0, 0, 1);
		velocity = -Vector3.Normalize(spaceObj.transform.position - transform.position) * spawnSpeed;
		velocity.x += Random.Range(-spawnDirectionVariance, spawnSpeedVariance);
		velocity.y += Random.Range(-spawnDirectionVariance, spawnSpeedVariance);
		velocity.z += Random.Range(-spawnDirectionVariance, spawnSpeedVariance);
		spaceObj.GetComponent<Rigidbody>().velocity = velocity;
		spaceObj.transform.localScale = new Vector3(size, size, size);
		spaceObj.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
	}
	
	Vector3 GetPosition(Quaternion rotation, Vector3 position, float distance) {
		Vector3 direction = rotation * Vector3.forward;
		return position + (direction  * distance);
	}

	/*
	 * Creates a random number that is varies by variance amount around value.
	 * Will never be a negative number.
	 *
	 */
	float varyValue(float value, float variance) {
		return value + ((value - variance < 0) ? Random.Range(0, variance) : Random.Range(-variance, variance));
	}
}
