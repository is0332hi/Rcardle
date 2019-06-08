using UnityEngine;
using System.Collections;

public class enemycharacter : MonoBehaviour {

    public static int HP;
    public static int Attackcount;
    public static int Defensecount;
    public static int Specialcount;
    private int[] select = new int[9] { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
    private int[] santa = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
    private int selectnum;
    public static int santanum;

	// Use this for initialization
	void Start () {
        HP = 3;
        Attackcount = 3;
        Defensecount = 3;
        Specialcount = 3;
    }
	
	// Update is called once per frame
	void Update () {
	    if(scenemanager.nextsection == scenemanager.NextSection.SELECT &&
           scenemanager.nextenemycharacterchoice == scenemanager.NextChoice.NONE)
        {
            do
            {
                selectnum = Random.Range(0, 9); // [0,8]
            } while (select[selectnum] == 0);
            switch(select[selectnum]){
                case 1: scenemanager.nextenemycharacterchoice = scenemanager.NextChoice.ATTACK; break;
                case 2: scenemanager.nextenemycharacterchoice = scenemanager.NextChoice.DEFENSE; break;
                case 3:
                    scenemanager.nextenemycharacterchoice = scenemanager.NextChoice.SPECIAL;
                    if (readyprocess.stagenum == 2)
                        scenemanager.enemypreactionflag = 1;
                    else if (readyprocess.stagenum == 5)
                        scenemanager.enemypreactionflag = 2;
                    else if (readyprocess.stagenum == 4)
                    {
                        santanum = santa[Random.Range(0, 8)];
                        switch (santanum)
                        {
                            case 2: scenemanager.enemypreactionflag = 1; break;
                            case 5: scenemanager.enemypreactionflag = 2; break;
                            default: scenemanager.enemypreactionflag = 0; break;
                        }
                    }


                        break;
            }
            select[selectnum] = 0;

        }
	}

}


