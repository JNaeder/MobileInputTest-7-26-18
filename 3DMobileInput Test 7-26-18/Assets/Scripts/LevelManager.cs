using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public GameObject pauseScreen;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void LoadScene(int sceneNum)
	{
		SceneManager.LoadScene(sceneNum);
		Time.timeScale = 1;
	}

	public void Pause()
	{
		Time.timeScale = 0;
		pauseScreen.SetActive(true);

	}

	public void UnPause()
	{
		Time.timeScale = 1;
		pauseScreen.SetActive(false);
	}

}
