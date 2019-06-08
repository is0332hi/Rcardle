using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class mon5 : monster
{

    bool sceneflag;

    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        sceneflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyprocess.stagenum == 5)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            Destroy(gameObject);
        }

        if (readyprocess.nextscene == readyprocess.NextScene.READY)
        {
            if (transform.position != new Vector3(-5, 2.5f))
            {
                base.startmove();
            }
            else if (transform.position == new Vector3(-5, 2.5f) && sceneflag == true)
            {
                SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
                sceneflag = false;
            }
        }
        else if (readyprocess.nextscene == readyprocess.NextScene.BATTLE)
        {
            base.enemyaction();
        }
    }
}
