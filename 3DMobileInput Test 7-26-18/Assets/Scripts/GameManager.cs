using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

    public GameObject pauseMenu, gameOverScreen;
    public int score;

    public TextMeshProUGUI scoreText, finalScoreText;

    PlaneMovement pM;
    DropperManager dM;

    public bool hasStarted;

	// Use this for initialization
	void Start () {
        pM = FindObjectOfType<PlaneMovement>();
        dM = FindObjectOfType<DropperManager>();
	}
	
	// Update is called once per frame
	void Update () {
        SeeIfStarted();
        scoreText.text = score.ToString();
	}

    void SeeIfStarted() {
        if (!hasStarted) {
            if (Input.touchCount > 0) {
                hasStarted = true;
                if (pM != null)
                {
                    pM.StartGame();
                }
                else if (dM != null) {
                    dM.StartGame();
                }
            }

        }

    }


    public void PrintSomething() {
        Debug.Log("test");
    }

    public void PauseGame() {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }


    public void UnPauseGame() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void GameOver() {
        Time.timeScale = 0;
        finalScoreText.text = score.ToString();
        gameOverScreen.SetActive(true);
    }


    
}
