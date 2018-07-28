using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixBall : MonoBehaviour {

	Rigidbody rB;

	// Use this for initialization
	void Start () {
		rB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		

	}


	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Platform"){
			rB.velocity = new Vector3(0, 10, 0);
			//Debug.Log(rB.velocity);

		}
	}
}
