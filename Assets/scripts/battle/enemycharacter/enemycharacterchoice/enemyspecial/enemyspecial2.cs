using UnityEngine;
using System.Collections;

public class enemyspecial2 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyprocess.stagenum == 2)
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
        if (readyprocess.stagenum == 2)
        {
            if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
            {
                eslarge2.descriptionflag = true;
            }
        }
    }

    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    void OnMouseExit()
    {
        if (readyprocess.stagenum == 2)
        {
            if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
            {
                eslarge2.descriptionflag = false;
            }
        }
    }

    // マウスカーソルが対象オブジェクトに進入した時にコールされる
    void OnMouseEnter()
    {
        if (readyprocess.stagenum == 2)
        {
            if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
            {
                eslarge2.descriptionflag = true;
            }
        }

    }
}
