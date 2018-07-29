using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterPlatformManager : MonoBehaviour {

	public int amountOfPlatforms;
	public float spaceBetweenPlatforms;
	public float piecesToDestroyThreshold;

	public GameObject platformPrefab;


	Transform ball;
	CameraFollow camFollow;

	PlatformGroup[] platforms;

	int platformNum;

	// Use this for initialization
	void Start () {
		SetUpPlatforms();

		ball = FindObjectOfType<HelixBall>().transform;
		camFollow = FindObjectOfType<CameraFollow>();


		platforms = GetComponentsInChildren<PlatformGroup>();
		Debug.Log(platforms.Length);
		camFollow.SetNewTransform(platforms[0].transform);
	}
	
	// Update is called once per frame
	void Update () {
        if (platformNum < platforms.Length)
        {
            if (ball.transform.position.y < platforms[platformNum].transform.position.y)
            {
                platforms[platformNum].DestroyPlatforms();
                platformNum++;
                camFollow.SetNewTransform(platforms[platformNum].transform);

            }
        }
	}



	void SetUpPlatforms(){
		for (int i = 0; i < amountOfPlatforms; i++){
			Vector3 newPlatformPos = new Vector3(0, -i * spaceBetweenPlatforms, 0);
			GameObject newPlatformGroup = Instantiate(platformPrefab, newPlatformPos, Quaternion.identity);
			newPlatformGroup.transform.parent = transform;
			PlatformGroup platformGroup = newPlatformGroup.GetComponent<PlatformGroup>();
			platformGroup.pieceDestroyThreshold = piecesToDestroyThreshold;
			platformGroup.SetUpPlatforms();

		}


	}
}
