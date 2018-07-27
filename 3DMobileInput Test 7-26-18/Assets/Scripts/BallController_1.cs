using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController_1 : MonoBehaviour {

    public float speed = 5f;
    public float roadWdith;

    public float fingerMult;

    Camera cam;
    Rigidbody rB;
    GameManager gM;

    Vector2 startPos, endPos, swipeDir;

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        rB = GetComponent<Rigidbody>();
        gM = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveByFingerDifference();
        ClampPosition();
    }


    void FollowFingerPosition() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = cam.ScreenToViewportPoint(touch.position);
            touchPos.x -= 0.5f;
            Debug.Log(touchPos.x);
            Vector3 newPos = new Vector3(touchPos.x * fingerMult, transform.position.y, transform.position.z);
            transform.position = newPos;

        }

    }


    void MoveByFingerDifference()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                startPos = cam.ScreenToViewportPoint(touch.position);

            }


            if (touch.phase == TouchPhase.Moved)
            {
                endPos = cam.ScreenToViewportPoint(touch.position);
                swipeDir = endPos - startPos;
                startPos = endPos;
                if (swipeDir != Vector2.zero)
                {
                    
                    transform.position += new Vector3(swipeDir.x * fingerMult, 0, 0);
                }
            }

        }

    }
    

    void ClampPosition() {
        Vector3 newPos = new Vector3(Mathf.Clamp(transform.position.x, -roadWdith, roadWdith), transform.position.y, transform.position.z);
        transform.position = newPos;

    }


    Vector2 FindSwipeDirection() {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPos = cam.ScreenToViewportPoint(touch.position);
                //rB.velocity = Vector3.zero;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endPos = cam.ScreenToViewportPoint(touch.position);
                swipeDir = endPos - startPos;
            }


        }
        else {
            swipeDir = Vector2.zero;
        }

        return swipeDir * speed;


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube") {
            gM.GameOver();

        }
    }

}
