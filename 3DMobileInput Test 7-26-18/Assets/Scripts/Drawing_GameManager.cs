﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Drawing_GameManager : MonoBehaviour {

	public GameObject line;
	public GameObject ball;
    public float gravityMult;

    public int score;
    public float timeScore;

    public TextMeshProUGUI scoreNum, WinScore, timeNum, winTimeScore ;

    bool hasStarted, hasWon;

    DrawCoin[] drawCoins;

    LevelManager lM;

	Rigidbody2D ballRB;

    Vector2 gravitySetting;
    float newTime;
    public int startingCoinNum, currentCoinNum;


    // Use this for initialization
    void Start () {
        lM = FindObjectOfType<LevelManager>();

		ballRB = ball.GetComponent<Rigidbody2D>();
        drawCoins = FindObjectsOfType<DrawCoin>();
        startingCoinNum = drawCoins.Length;
        currentCoinNum = startingCoinNum;
	}

	
	// Update is called once per frame
	void Update () {
        SetGravity();
        CheckWin();
        scoreNum.text = score.ToString();
        WinScore.text = score.ToString();
        timeNum.text = timeScore.ToString("F2");
        winTimeScore.text = timeScore.ToString("F2");


        if (hasStarted) {
            
                timeScore = Time.time - newTime;
            
        }

		if(Input.touchCount  > 0){
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Began){
				GameObject newLine = Instantiate(line, Vector2.zero, Quaternion.identity);

			}


			if(touch.phase == TouchPhase.Ended){



			}

		}

	}


    void CheckWin() {
        if (currentCoinNum <= 0) {
            lM.WinScreen();

        }
        hasWon = true;
    }


    void SetGravity() {
        Vector2 accelPos = Input.acceleration * gravityMult;
        Physics2D.gravity = accelPos;


    }



	public void DropBall(){
		ballRB.isKinematic = false;
        newTime = Time.time;
        hasStarted = true;
	}


}
