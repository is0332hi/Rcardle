﻿using UnityEngine;
using System.Collections;

public class edx3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (enemycharacter.Defensecount == 3)
            GetComponent<Renderer>().enabled = true;
        else
            GetComponent<Renderer>().enabled = false;
    }
}
