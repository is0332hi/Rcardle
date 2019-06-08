using UnityEngine;
using System.Collections;

public class eslarge2 : MonoBehaviour {

    public static bool descriptionflag;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        descriptionflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyprocess.stagenum == 2)
        {
            if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
            {
                if (descriptionflag)
                {
                    GetComponent<Renderer>().enabled = true;
                }
                else
                {
                    GetComponent<Renderer>().enabled = false;
                }
            }
            else if (scenemanager.nextsection == scenemanager.NextSection.ACTION ||
                     scenemanager.nextsection == scenemanager.NextSection.JUDGE)
            {
                if (scenemanager.nextenemycharacterchoice == scenemanager.NextChoice.SPECIAL)
                    GetComponent<Renderer>().enabled = true;
                else
                    GetComponent<Renderer>().enabled = false;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
