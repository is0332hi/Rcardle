using UnityEngine;
using System.Collections;

public class csx3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
    }   
	
	// Update is called once per frame
	void Update () {
        if (maincharacter.Specialcount == 3)
            GetComponent<Renderer>().enabled = true;
        else
            GetComponent<Renderer>().enabled = false;
    }
}
