﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float speed;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);

		
	}



	public void SetNewTransform(Transform newTrans){
		target = newTrans;

	}
}
