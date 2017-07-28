using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    int healthPoints = 100;
    int defencePoints = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (defencePoints > 100)
        {
            defencePoints = 100;
        }

        if (defencePoints <= 0)
        {
            defencePoints = 0;
            Debug.Log("Object defences have been decimated.");
        }

        if (healthPoints > 100)
        {
            healthPoints = 100;
        }

        if(healthPoints <= 0)
        {
            healthPoints = 0;
            Debug.Log("Object has been decimated.");
        }
        
	}
}
