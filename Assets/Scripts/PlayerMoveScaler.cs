using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScaler : MonoBehaviour {
    public GameObject player;
    public GameObject parent;
    public GameData gameData;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 handOrt = transform.position - parent.transform.position;

        player.transform.position = (transform.position - handOrt) + (handOrt * gameData.playerSize/5);
        player.transform.rotation = transform.rotation;
	}
}
