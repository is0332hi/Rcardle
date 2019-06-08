using UnityEngine;
using System.Collections;

public class maincharacterattack0 : MonoBehaviour
{    
    // Update is called once per frame
    void Update()
    {
        if (scenemanager.maincharacterpowerflag)
        {
            GetComponent<Renderer>().enabled = false;
            transform.position = new Vector3(-2, -7);
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
            transform.position = new Vector3(-2, -3);
        }
    }

    //マウスクリックした時にコールされる
    void OnMouseDown()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            if (maincharacter.Attackcount != 0)
            {
                scenemanager.nextsection = scenemanager.NextSection.ACTION;
                scenemanager.nextmaincharacterchoice = scenemanager.NextChoice.ATTACK;
                transform.localScale = new Vector3(0.75f, 0.8f);
            }
            //else
        }
    }

    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    void OnMouseOver()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            calarge0.descriptionflag = true;
            transform.localScale = new Vector3(0.8f, 0.85f);
        }
    }

    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    void OnMouseExit()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            calarge0.descriptionflag = false;
            transform.localScale = new Vector3(0.75f, 0.8f);
        }
    }

    // マウスカーソルが対象オブジェクトに進入した時にコールされる
    void OnMouseEnter()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            calarge0.descriptionflag = true;
            transform.localScale = new Vector3(0.8f, 0.85f);
        }

    }
}

