using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//全体的に継承でもっとスマートに
//しかしながら興味がわかなくなったら次へ移るのがゲーム作成で肝心
//数
//シンプル差を保ちながらゲーム性を高く　要素数最小で考えた

//コメント

public class scenemanager : MonoBehaviour {

    private const int STAGE = 7;
    private const int MAXTURN = 9;

    public enum NextSection
    {
        SELECT,
        ACTION,

        JUDGE,
    }
    public enum NextChoice
    {
        ATTACK,
        DEFENSE,
        SPECIAL,

        NONE,
    }
    public enum NextCharacter
    {
        MAIN,
        ENEMY,
    }

    public static NextSection nextsection;
    public static NextCharacter nextcharacter;

    public static NextChoice nextmaincharacterchoice;
    public static NextChoice nextenemycharacterchoice;

     
    private int[] preation = new int[6] { 1, 0, 0, 0, 0, 0 };         // 1/6で相手が先制する　抽選用
    private int preationed;                                           //抽選結果保存用
    private int turn;                               //現在ターン数

    private int maincharacterdamaged;               //カウンター用被ダメージ
    private int enemydamaged;

    public static bool maincharacterpowerflag;      //改心の一撃フラグ
    public static bool enemypowerflag;

    public static int maincharacterpreactionflag;   //0 初期 1 先制　2後攻
    public static int enemypreactionflag;

    public static int maincharacteractionnumber;    //0 未行動 1 行動中 2 行動後
    public static int enemyactionnumber;
                
    // Use this for initialization
    void Start()
    {                                                    //初期化
        nextsection = NextSection.SELECT;                       
        nextmaincharacterchoice = NextChoice.NONE;
        nextenemycharacterchoice = NextChoice.NONE;
        nextcharacter = NextCharacter.MAIN;
        turn = 1;
        maincharacterpowerflag = false;
        enemypowerflag = false;
        maincharacterdamaged = 0;
        enemydamaged = 0;
        maincharacterpreactionflag = 0;
        enemypreactionflag = 0;
        maincharacteractionnumber = 0;
        enemyactionnumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (nextsection)
        {
            case NextSection.SELECT:
                preationed = preation[Random.Range(0, 6)];
                break;

            case NextSection.ACTION:
                if (maincharacteractionnumber == 0 && enemyactionnumber == 0)
                {
                    if (maincharacterpreactionflag == 1 || enemypreactionflag == 2)
                    {
                        nextcharacter = NextCharacter.MAIN;
                    }
                    else if (enemypreactionflag == 1 || maincharacterpreactionflag == 2 || preationed == 1)
                    {
                        nextcharacter = NextCharacter.ENEMY;
                    }
                    else
                    {
                        nextcharacter = NextCharacter.MAIN;
                    }
                }

                readyprocess.nextscene = readyprocess.NextScene.BATTLE;

                if (nextcharacter == NextCharacter.MAIN && maincharacteractionnumber == 0)
                {
                    maincharacteractionnumber = 1;

                    switch (nextmaincharacterchoice)
                    {
                        case NextChoice.ATTACK:
                            maincharacter.Attackcount--;
                            if (nextenemycharacterchoice != NextChoice.DEFENSE)
                            {
                                character.nextaction = character.Nextaction.Charge;
                                if (maincharacterpowerflag)
                                {
                                    enemycharacter.HP -= 3;  //改心の一撃
                                    enemydamaged = 3;
                                }
                                else
                                {
                                    enemycharacter.HP--;
                                    enemydamaged = 1;
                                }
                            }
                            else
                            {
                                maincharacteractionnumber = 2;
                            }
                            maincharacterpowerflag = false;
                            break;

                        case NextChoice.DEFENSE:
                            maincharacter.Defensecount--;
                            maincharacteractionnumber = 2;
                            break;

                        case NextChoice.SPECIAL:
                            maincharacter.Specialcount--;
                            switch (readyprocess.maincharacternum)
                            {
                                case 0:
                                    character.nextaction = character.Nextaction.Charge;
                                    enemycharacter.HP -= 1;
                                    enemydamaged = 1;
                                    break;                                       //精神攻撃

                                case 1:
                                    maincharacteractionnumber = 2;
                                    break;                                       //なにもしない

                                case 2:
                                    if (nextenemycharacterchoice != NextChoice.DEFENSE)
                                    {
                                        character.nextaction = character.Nextaction.Charge;
                                        enemycharacter.HP--;
                                        enemydamaged = 1;
                                    }
                                    else
                                    {
                                        maincharacteractionnumber = 2;
                                    }
                                    break;

                                case 3:                                                 //力の集約
                                    maincharacterpowerflag = true;
                                    maincharacteractionnumber = 2;
                                    break;

                                case 4:
                                    switch (maincharacterspecial4.santanum)
                                    {
                                        case 0:
                                            character.nextaction = character.Nextaction.Charge;
                                            enemycharacter.HP -= 1;
                                            enemydamaged = 1;
                                            Debug.Log("0");
                                            break;
                                        case 1:
                                            maincharacteractionnumber = 2;
                                            Debug.Log("1");
                                            break;
                                        case 2:
                                            if (nextenemycharacterchoice != NextChoice.DEFENSE)
                                            {
                                                character.nextaction = character.Nextaction.Charge;
                                                enemycharacter.HP--;
                                                enemydamaged = 1;
                                            }
                                            else
                                            {
                                                maincharacteractionnumber = 2;
                                            }
                                            Debug.Log("2");
                                            break;
                                        case 3:
                                            maincharacterpowerflag = true;
                                            maincharacteractionnumber = 2;
                                            Debug.Log("3");
                                            break;
                                        case 4:
                                            maincharacteractionnumber = 2;
                                            Debug.Log("4");
                                            break;
                                        case 5:
                                            if (nextenemycharacterchoice != NextChoice.DEFENSE)
                                            {
                                                character.nextaction = character.Nextaction.Charge;
                                                enemycharacter.HP -= 2 * maincharacterdamaged;
                                                enemydamaged = 2 * maincharacterdamaged;
                                            }
                                            else
                                            {
                                                maincharacteractionnumber = 2;
                                            }
                                            Debug.Log("5");
                                            break;
                                        case 6:
                                            if (nextenemycharacterchoice != NextChoice.DEFENSE)
                                            {
                                                character.nextaction = character.Nextaction.Charge;
                                                enemycharacter.HP -= 2;
                                                enemydamaged = 2;
                                            }
                                            else
                                            {
                                                maincharacteractionnumber = 2;
                                            }
                                            Debug.Log("6");
                                            break;
                                        case 7:
                                            if (nextenemycharacterchoice != NextChoice.DEFENSE)
                                            {
                                                character.nextaction = character.Nextaction.Charge;
                                                enemycharacter.HP -= 1;
                                                enemydamaged = 1;
                                                maincharacter.HP += 2;
                                                if (maincharacter.HP > 4)
                                                    maincharacter.HP = 4;
                                            }
                                            else
                                            {
                                                maincharacteractionnumber = 2;
                                            }
                                            Debug.Log("7");
                                            break;

                                    }
                                    break;

                                case 5:
                                    if (nextenemycharacterchoice != NextChoice.DEFENSE)
                                    {
                                        character.nextaction = character.Nextaction.Charge;
                                        enemycharacter.HP -= 2 * maincharacterdamaged;
                                        enemydamaged = 2 * maincharacterdamaged;
                                    }
                                    else
                                    {
                                        maincharacteractionnumber = 2;
                                    }
                                    break;

                                case 6:
                                    if (nextenemycharacterchoice != NextChoice.DEFENSE)
                                    {
                                        character.nextaction = character.Nextaction.Charge;
                                        enemycharacter.HP -= 2;
                                        enemydamaged = 2;
                                    }
                                    else
                                    {
                                        maincharacteractionnumber = 2;
                                    }
                                    break;
                            }
                            break;
                    }
                }
                else if (nextcharacter == NextCharacter.ENEMY && enemyactionnumber == 0)
                {
                    enemyactionnumber = 1;

                    switch (nextenemycharacterchoice)
                    {
                        case NextChoice.ATTACK:
                            enemycharacter.Attackcount--;
                            if (nextmaincharacterchoice != NextChoice.DEFENSE)
                            {
                                monster.nextaction = monster.Nextaction.Charge;
                                if (enemypowerflag)
                                {
                                    maincharacter.HP = -3;  //改心の一撃
                                    maincharacterdamaged = 3;
                                }
                                else
                                {
                                    maincharacter.HP--;
                                    maincharacterdamaged = 1;
                                }
                            }
                            else
                            {
                                enemyactionnumber = 2;
                            }
                            enemypowerflag = false;
                            break;

                        case NextChoice.DEFENSE:
                            enemycharacter.Defensecount--;
                            enemyactionnumber = 2;
                            break;

                        case NextChoice.SPECIAL:
                            enemycharacter.Specialcount--;
                            switch (readyprocess.stagenum)
                            {
                                case 1:
                                    enemyactionnumber = 2;
                                    break;                                             //なにもしない

                                case 2:
                                    if (nextmaincharacterchoice != NextChoice.DEFENSE)
                                    {
                                        monster.nextaction = monster.Nextaction.Charge;
                                        maincharacter.HP--;
                                        maincharacterdamaged = 1;
                                    }
                                    else
                                    {
                                        enemyactionnumber = 2;
                                    }
                                    break;

                                case 3:                                                //力の集約
                                    enemypowerflag = true;
                                    enemyactionnumber = 2;
                                    break;

                                case 4:
                                    switch (enemycharacter.santanum)
                                    {
                                        case 0:
                                            monster.nextaction = monster.Nextaction.Charge;
                                            maincharacter.HP -= 1;
                                            maincharacterdamaged = 1;
                                            Debug.Log("0");
                                            break;
                                        case 1:
                                            enemyactionnumber = 2;
                                            Debug.Log("1");
                                            break;
                                        case 2:
                                            if (nextmaincharacterchoice != NextChoice.DEFENSE)
                                            {
                                                monster.nextaction = monster.Nextaction.Charge;
                                                maincharacter.HP--;
                                                maincharacterdamaged = 1;
                                            }
                                            else
                                            {
                                                enemyactionnumber = 2;
                                            }
                                            Debug.Log("2");
                                            break;
                                        case 3:
                                            enemypowerflag = true;
                                            enemyactionnumber = 2;
                                            Debug.Log("3");
                                            break;
                                        case 4:
                                            enemyactionnumber = 2;
                                            Debug.Log("4");
                                            break;
                                        case 5:
                                            if (nextmaincharacterchoice != NextChoice.DEFENSE)
                                            {
                                                monster.nextaction = monster.Nextaction.Charge;
                                                maincharacter.HP -= 2 * enemydamaged;
                                                maincharacterdamaged = 2 * enemydamaged;
                                            }
                                            else
                                            {
                                                enemyactionnumber = 2;
                                            }
                                            Debug.Log("5");
                                            break;
                                        case 6:
                                            if (nextmaincharacterchoice != NextChoice.DEFENSE) 
                                            {
                                                monster.nextaction = monster.Nextaction.Charge;
                                                maincharacter.HP -= 2;
                                                maincharacterdamaged = 2;
                                            }
                                            else
                                            {
                                                enemyactionnumber = 2;
                                            }
                                            Debug.Log("6");
                                            break;
                                        case 7:
                                            if (nextmaincharacterchoice != NextChoice.DEFENSE)
                                            {
                                                monster.nextaction = monster.Nextaction.Charge;
                                                maincharacter.HP -= 1;
                                                maincharacterdamaged = 1;
                                                enemycharacter.HP += 2;
                                                if (enemycharacter.HP > 4)
                                                    enemycharacter.HP = 4;
                                            }
                                            else
                                            {
                                                enemyactionnumber = 2;
                                            }
                                            Debug.Log("7");
                                            break;
                                    }
                                    break;

                                case 5:
                                    if (nextmaincharacterchoice != NextChoice.DEFENSE)
                                    {
                                        monster.nextaction = monster.Nextaction.Charge;
                                        maincharacter.HP -= 2 * enemydamaged;
                                        maincharacterdamaged = 2 * enemydamaged;
                                    }
                                    else
                                    {
                                        enemyactionnumber = 2;
                                    }
                                    break;

                                case 6:
                                    if (nextmaincharacterchoice != NextChoice.DEFENSE) //ドラゴンブレス
                                    {
                                        monster.nextaction = monster.Nextaction.Charge;
                                        maincharacter.HP -= 2;
                                        maincharacterdamaged = 2;
                                    }
                                    else
                                    {
                                        enemyactionnumber = 2;
                                    }
                                    break;

                                case 7:
                                    if (nextmaincharacterchoice != NextChoice.DEFENSE)
                                    {
                                        monster.nextaction = monster.Nextaction.Charge;
                                        maincharacter.HP -= 1;
                                        maincharacterdamaged = 1;
                                        enemycharacter.HP += 2;
                                        if (enemycharacter.HP > 4)
                                            enemycharacter.HP = 4;
                                    }
                                    else
                                    {
                                        enemyactionnumber = 2;
                                    }
                                    break;

                            }
                            break;
                    }
                }
                nextsection = NextSection.JUDGE;
                break;

            case NextSection.JUDGE:

                if (maincharacteractionnumber == 2 && enemyactionnumber == 2)          //１ターン終了初期化
                {
                    nextsection = NextSection.SELECT;
                    nextmaincharacterchoice = NextChoice.NONE;
                    nextenemycharacterchoice = NextChoice.NONE;
                    maincharacteractionnumber = 0;
                    enemyactionnumber = 0;
                    maincharacterdamaged = 0;
                    enemydamaged = 0;
                    maincharacterpreactionflag = 0;
                    enemypreactionflag = 0;
                    turn++;
                }
                else if (maincharacteractionnumber == 2 && enemyactionnumber != 2 )
                {
                    nextcharacter = NextCharacter.ENEMY;
                    nextsection = NextSection.ACTION;
                }
                else if (maincharacteractionnumber != 2 && enemyactionnumber == 2)
                {
                    nextcharacter = NextCharacter.MAIN;
                    nextsection = NextSection.ACTION;
                }
                break;
        }

        //状態遷移確認
        if ((maincharacteractionnumber == 2 && enemycharacter.HP <= 0) || turn == MAXTURN + 1)
        {
            readyprocess.nextscene = readyprocess.NextScene.RESULT;
            SceneManager.LoadScene("result", LoadSceneMode.Additive);
            readyprocess.stagenum++;
            SceneManager.UnloadScene("battle");
        }
        else if (enemyactionnumber == 2 && maincharacter.HP <= 0)
        {
            SceneManager.LoadScene("gameover");
            readyprocess.stagenum = 1;
            readyprocess.maincharacternum = 0;
        }
        
        if (readyprocess.stagenum == STAGE + 1)   //ステージ数
        {
            SceneManager.LoadScene("clear");
            readyprocess.stagenum = 1;
            readyprocess.maincharacternum = 0;
        }
    }

}

