using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperManager : MonoBehaviour {
    public GameObject coin;
    public float spawnRate;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnItem() {
        Instantiate(coin, transform.position, Quaternion.identity);

    }

    public void StartGame() {
        InvokeRepeating("SpawnItem", 0.01f, spawnRate);

    }
}
