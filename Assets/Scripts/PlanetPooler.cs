using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPooler : MonoBehaviour {

	[System.Serializable]
	public class Pool {
		public string tag;
		public GameObject prefab;
		public int size;
	}

	#region Singletone
	public static PlanetPooler Instance;

	private void Awake() {
		Instance = this;
	}
	#endregion

	public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDict;

	void Start () {
		poolDict = new Dictionary<string, Queue<GameObject>>();

		foreach (Pool pool in pools) {
			Queue<GameObject> planetPool = new Queue<GameObject>();

			for (int i = 0; i < pool.size; i++) {
				GameObject obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				planetPool.Enqueue(obj);
			}

			poolDict.Add(pool.tag, planetPool);
		}
	}
	

	public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation) {
		// check if prefab exists
		if (!poolDict.ContainsKey(tag)) {
			Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
			return null;
		}
		GameObject objectToSpawn = poolDict[tag].Dequeue();

		objectToSpawn.SetActive(true);
		objectToSpawn.transform.position = position;
		objectToSpawn.transform.rotation = rotation;

		IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

		if (pooledObj != null) {
			pooledObj.OnObjectSpawn();
		}

		poolDict[tag].Enqueue(objectToSpawn);

		return objectToSpawn;
	}
}
