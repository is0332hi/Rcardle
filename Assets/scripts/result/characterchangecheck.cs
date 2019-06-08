using UnityEngine;
using System.Collections;

public class characterchangecheck : MonoBehaviour {

    public static bool checkflag;
    public static bool changeflag;

    // Use this for initialization
    void Start()
    {
        checkflag = false;
        changeflag = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (changeflag)
        {
            readyprocess.maincharacternum = readyprocess.stagenum - 1;
            changeflag = false;
        }
   	}
}
