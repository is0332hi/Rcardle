using UnityEngine;
using System.Collections;

public class enemyattack1 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        if (readyprocess.stagenum != 3 && readyprocess.stagenum != 4)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scenemanager.enemypowerflag)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
        }
    }

    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    void OnMouseOver()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            ealarge1.descriptionflag = true;
        }
    }

    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    void OnMouseExit()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            ealarge1.descriptionflag = false;
        }
    }

    // マウスカーソルが対象オブジェクトに進入した時にコールされる
    void OnMouseEnter()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            ealarge1.descriptionflag = true;
        }

    }
}
