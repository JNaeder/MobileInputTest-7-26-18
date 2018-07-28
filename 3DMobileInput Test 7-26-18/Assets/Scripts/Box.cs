using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public float speed;

	OneTouch_GameManager gM;

	// Use this for initialization
	void Start () {
		gM = FindObjectOfType<OneTouch_GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;


	}


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player"){
			speed = 0;
			gM.score++;

		}
	}
}
