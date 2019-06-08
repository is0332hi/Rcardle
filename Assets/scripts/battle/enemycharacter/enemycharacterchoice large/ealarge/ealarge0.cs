using UnityEngine;
using System.Collections;

public class ealarge0 : MonoBehaviour
{
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
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            if (descriptionflag && !scenemanager.enemypowerflag)
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
            if (scenemanager.nextenemycharacterchoice == scenemanager.NextChoice.ATTACK && !scenemanager.enemypowerflag)
                GetComponent<Renderer>().enabled = true;
            else
                GetComponent<Renderer>().enabled = false;
        }
    }
}
