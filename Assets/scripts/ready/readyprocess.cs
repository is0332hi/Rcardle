using UnityEngine;
using System.Collections;

public class readyprocess : MonoBehaviour {

    public enum NextScene
    {
        READY,
        BATTLE,
        RESULT,
        END,
    }

    public static NextScene nextscene;
    public static int stagenum = 1;            //ステージ数
    public static int maincharacternum = 0;    //キャラクターの種類

	// Use this for initialization
	void Start () {
        nextscene = NextScene.READY;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
