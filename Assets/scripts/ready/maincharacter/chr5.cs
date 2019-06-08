using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class chr5 : character
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyprocess.maincharacternum == 5)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
        }

        if (readyprocess.nextscene == readyprocess.NextScene.READY)
        {
            if (transform.position != new Vector3(-5, -2.5f))
            {
                base.startmove();
            }
        }
        else if (readyprocess.nextscene == readyprocess.NextScene.BATTLE)
        {
            base.characteraction();
        }
        else if (readyprocess.nextscene == readyprocess.NextScene.RESULT)
        {
            if (transform.position != new Vector3(-5, 2.5f))
            {
                base.resultmove();
            }
            else if (transform.position == new Vector3(-5, 2.5f))
            {
                characterchangecheck.checkflag = true;
            }
        }
        else if (readyprocess.nextscene == readyprocess.NextScene.END && readyprocess.maincharacternum == 5)
        {
            if (transform.position != new Vector3(-5, 7f))
            {
                base.endmove();
            }
            else if (transform.position == new Vector3(-5, 7f))
            {
                SceneManager.LoadScene("ready");
            }
        }
    }
}
