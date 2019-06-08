using UnityEngine;
using System.Collections;

public class calarge1 : MonoBehaviour
{

    public static bool descriptionflag;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        descriptionflag = false;
        if (readyprocess.maincharacternum != 3 && readyprocess.maincharacternum != 4)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            if (descriptionflag && scenemanager.maincharacterpowerflag)
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
            if (scenemanager.nextmaincharacterchoice == scenemanager.NextChoice.ATTACK && scenemanager.maincharacterpowerflag)
                GetComponent<Renderer>().enabled = true;
            else
                GetComponent<Renderer>().enabled = false;
        }
    }
}
