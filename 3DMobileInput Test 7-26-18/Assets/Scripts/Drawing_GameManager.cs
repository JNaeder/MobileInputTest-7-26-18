using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing_GameManager : MonoBehaviour {

	public GameObject line;

	public GameObject ball;
	Rigidbody2D ballRB;

	// Use this for initialization
	void Start () {

		ballRB = ball.GetComponent<Rigidbody2D>();
	}

	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount  > 0){
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began){
				GameObject newLine = Instantiate(line, Vector2.zero, Quaternion.identity);

			}


			if(touch.phase == TouchPhase.Ended){



			}

		}

	}


	public void DropBall(){
		ballRB.isKinematic = false;


	}


}
