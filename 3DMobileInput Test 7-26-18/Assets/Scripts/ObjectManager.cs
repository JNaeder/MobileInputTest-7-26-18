using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    public GameObject cube, coin;
    public Transform objectCreateTransform;
    public Transform enviro;
    public float roadWidth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateNewObject() {
        CreateCube();
        CreateCoin();
    }

    void CreateCube() {
        float newXPos = Random.Range(-roadWidth, roadWidth);
        Vector3 newPos = new Vector3(objectCreateTransform.position.x - newXPos, 1, objectCreateTransform.position.z);
        GameObject newCube = Instantiate(cube, newPos, Quaternion.identity);
        newCube.transform.parent = enviro;

    }


    void CreateCoin() {
        float newXPos = Random.Range(-roadWidth, roadWidth);
        Vector3 newPos = new Vector3(objectCreateTransform.position.x - newXPos, 1, objectCreateTransform.position.z);
        GameObject newCube = Instantiate(coin, newPos, Quaternion.identity);
        newCube.transform.parent = enviro;

    }
}
