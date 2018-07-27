using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotation : MonoBehaviour {
    public float fingerMult;


    Camera cam;
    Rigidbody rB;

    Vector2 touchPos;

    Vector2 startPos, endPos, swipeDir;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        rB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        RotateBall();
		
	}


    void RotateBall() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPos = cam.ScreenToViewportPoint(touch.position);
                
            }


            if (touch.phase == TouchPhase.Moved)
            {
                endPos = cam.ScreenToViewportPoint(touch.position);
                swipeDir = endPos - startPos;
                startPos = endPos;
                if (swipeDir != Vector2.zero)
                {
                    Vector3 newRot = new Vector3(swipeDir.y * fingerMult, -swipeDir.x * fingerMult, 0);
                    //transform.Rotate(newRot, Space.World);
                    rB.AddTorque(newRot, ForceMode.Acceleration);
                    
                }
            }

        }

    }
    
}
