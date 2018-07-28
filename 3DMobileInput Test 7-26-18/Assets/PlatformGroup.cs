using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGroup : MonoBehaviour {
	Transform[] pieces;

	public float pieceDestroyThreshold;

	private void Start()
	{
		     
	}


	public void DestroyPlatforms(){
		Destroy(gameObject);

	}

	public void SetUpPlatforms(){
		pieces = GetComponentsInChildren<Transform>();

        for (int i = 1; i < pieces.Length; i++)
        {
            float randNum = Random.Range(0, 100);
            if (randNum < pieceDestroyThreshold)
            {
                Destroy(pieces[i].gameObject);
            }
        }

	}

}
