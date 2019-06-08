using UnityEngine;
using System.Collections;

public class resultdescriotion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {
        if (characterchangecheck.checkflag)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
        }
	}
}
