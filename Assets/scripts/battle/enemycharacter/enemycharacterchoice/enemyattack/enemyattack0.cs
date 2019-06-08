using UnityEngine;
using System.Collections;

public class enemyattack0 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scenemanager.enemypowerflag)
        {
            GetComponent<Renderer>().enabled = false;
            transform.position = new Vector3(-2, 7);
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
            transform.position = new Vector3(-2, 3);
        }
    }

    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    void OnMouseOver()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            ealarge0.descriptionflag = true;
        }
    }

    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    void OnMouseExit()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            ealarge0.descriptionflag = false;
        }
    }

    // マウスカーソルが対象オブジェクトに進入した時にコールされる
    void OnMouseEnter()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            ealarge0.descriptionflag = true;
        }

    }
}
