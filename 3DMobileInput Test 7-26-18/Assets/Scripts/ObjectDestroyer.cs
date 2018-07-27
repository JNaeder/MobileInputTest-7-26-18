using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    ObjectManager oM;
    PlaneMovement pM;

	// Use this for initialization
	void Start () {
        oM = GetComponentInParent<ObjectManager>();
        pM = FindObjectOfType<PlaneMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {

            oM.CreateNewObject();
            Destroy(other.gameObject);
            
        }
    }
}
