using UnityEngine;
using System.Collections;

public class ybutton : MonoBehaviour {

    public void yesdown()
    {
        characterchangecheck.changeflag = true;
        characterchangecheck.checkflag = false;
        readyprocess.nextscene = readyprocess.NextScene.END;
    }
}
