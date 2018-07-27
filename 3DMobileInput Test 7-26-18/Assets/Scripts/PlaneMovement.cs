using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {

    public float speed = 1f;

    float realSpeed;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(0, 0, -1) * Time.deltaTime * realSpeed;


	}

    public void StartGame() {
        realSpeed = speed;
    }
}
