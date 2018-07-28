using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixGameManager : MonoBehaviour {

	public Transform bar, platforms;
	public float fingerMult;

	Rigidbody barRB;

	Camera cam;

	Vector2 startPos, endPos, swipeDir;

	// Use this for initialization
	void Start () {
		cam = Camera.main;

		barRB = bar.GetComponent<Rigidbody>();

		Physics.gravity = new Vector3(0, -15f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		CheckSwipePosition();

		platforms.rotation = bar.rotation;
	}




	void CheckSwipePosition(){
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began){
				startPos = cam.ScreenToViewportPoint(touch.position);
				barRB.angularVelocity = Vector2.zero;

			} else if( touch.phase == TouchPhase.Moved){
				endPos = cam.ScreenToViewportPoint(touch.position);
				swipeDir = (endPos - startPos) * fingerMult;
				RotateBar(swipeDir.x);
				startPos = endPos;

			} 

			if(swipeDir != Vector2.zero){
				//Debug.Log(swipeDir);

			}
		} else
        {
                     
        }


	}


	void RotateBar(float rotSpeed){
		//bar.transform.Rotate(new Vector3(0, -rotSpeed, 0));
		barRB.AddTorque(new Vector3(0, -rotSpeed, 0));



	}
}
