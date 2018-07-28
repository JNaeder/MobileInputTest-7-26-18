using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnerManager : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject box;
	public float spawnRate;

	float newY;

	public bool hasStarted;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			if(Input.touchCount > 0){
				Touch touch = Input.GetTouch(0);
				if(touch.phase == TouchPhase.Began){
					InvokeRepeating("SpawnBox", 0.01f, (1 / spawnRate));
					hasStarted = true;
				}
			}

		}
		
	}

	void SpawnBox(){
		Vector3 newPos = new Vector3(spawnPoints[0].position.x, spawnPoints[0].position.y + newY, spawnPoints[0].position.z);
		Instantiate(box, newPos, Quaternion.identity);


		newY++;

	}
}
