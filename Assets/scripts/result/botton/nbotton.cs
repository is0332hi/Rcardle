using UnityEngine;
using System.Collections;

public class nbotton : MonoBehaviour {

    public void nodown()
    {
        characterchangecheck.changeflag = false;
        characterchangecheck.checkflag = false;
        readyprocess.nextscene = readyprocess.NextScene.END;
    }
}
