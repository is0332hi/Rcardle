﻿using UnityEngine;
using System.Collections;

public class edx2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (enemycharacter.Defensecount == 2)
            GetComponent<Renderer>().enabled = true;
        else
            GetComponent<Renderer>().enabled = false;
    }
}
