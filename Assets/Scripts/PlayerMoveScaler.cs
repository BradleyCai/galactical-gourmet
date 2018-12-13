using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that moves the player based on hand controller, and also scales it's distance based on the playerSize
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
        float handicapSize = gameData.playerSize + (gameData.playerSize / 10);

        if (!gameData.isDebugging)
            player.transform.position = transform.position + handOrt * 2 + handOrt * gameData.playerSize;
        else
            player.transform.position = transform.position + (transform.forward * 0.8f) + transform.forward * gameData.playerSize;

        player.transform.localScale = new Vector3(handicapSize, handicapSize, handicapSize);
        player.transform.rotation = transform.rotation;
	}
}
