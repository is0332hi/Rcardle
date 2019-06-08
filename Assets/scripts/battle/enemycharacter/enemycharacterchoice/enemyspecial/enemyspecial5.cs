using UnityEngine;
using System.Collections;

public class enemyspecial5 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
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
    }

    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    void OnMouseOver()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            eslarge5.descriptionflag = true;
        }
    }

    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    void OnMouseExit()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            eslarge5.descriptionflag = false;
        }
    }

    // マウスカーソルが対象オブジェクトに進入した時にコールされる
    void OnMouseEnter()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            eslarge5.descriptionflag = true;
        }

    }
}
