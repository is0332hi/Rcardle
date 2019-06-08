using UnityEngine;
using System.Collections;

public class cax1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
    }

	
	// Update is called once per frame
	void Update () {
        if (maincharacter.Attackcount == 1)
            GetComponent<Renderer>().enabled = true;
        else
            GetComponent<Renderer>().enabled = false;
    }
}
