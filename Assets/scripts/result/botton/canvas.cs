using UnityEngine;
using System.Collections;

public class canvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (characterchangecheck.checkflag)
        {
            GetComponent<Canvas>().enabled = true;
        }
        else
        {
            GetComponent<Canvas>().enabled = false;
        }
    }
}
