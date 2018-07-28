using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OneTouch_GameManager : MonoBehaviour {


	public Transform ball;
	public float jumpForce;
	public int score;

	public TextMeshProUGUI scoreNum;
	public GameObject pauseMenu, gameOverScreen;


	Rigidbody rB;

	BoxSpawnerManager bSM;

	// Use this for initialization
	void Start () {
		rB = ball.GetComponent<Rigidbody>();
		bSM = FindObjectOfType<BoxSpawnerManager>();

		Physics.gravity = new Vector3(0, -15, 0);
	}
	
	// Update is called once per frame
	void Update () {
		scoreNum.text = score.ToString();

		if (bSM.hasStarted)
		{

			OneTouch();
		}



	}

	public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }


    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

	void OneTouch(){
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began){
				rB.AddForce(Vector3.up * jumpForce * 100);


			}


		}


	}




}
