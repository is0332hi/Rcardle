using UnityEngine;
using System.Collections;

public class maincharacterspecial1 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (readyprocess.maincharacternum == 1)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //マウスクリックした時にコールされる
    void OnMouseDown()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            if (maincharacter.Specialcount != 0)
            {
                scenemanager.nextsection = scenemanager.NextSection.ACTION;
                scenemanager.nextmaincharacterchoice = scenemanager.NextChoice.SPECIAL;
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
            cslarge1.descriptionflag = true;
            transform.localScale = new Vector3(0.8f, 0.85f);
        }
    }

    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    void OnMouseExit()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            cslarge1.descriptionflag = false;
            transform.localScale = new Vector3(0.75f, 0.8f);
        }
    }

    // マウスカーソルが対象オブジェクトに進入した時にコールされる
    void OnMouseEnter()
    {
        if (scenemanager.nextsection == scenemanager.NextSection.SELECT)
        {
            cslarge1.descriptionflag = true;
            transform.localScale = new Vector3(0.8f, 0.85f);
        }

    }
}
