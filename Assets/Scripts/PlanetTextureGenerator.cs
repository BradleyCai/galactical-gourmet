using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTextureGenerator : MonoBehaviour {

	public Texture[] textures;


	// Use this for initialization
	void Start () {
		int size = textures.Length;
		GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, size)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
