using UnityEngine;
using System.Collections;

public class maincharacter : MonoBehaviour {

    public static int HP;
    public static int Attackcount;
    public static int Defensecount;
    public static int Specialcount;

    // Use this for initialization
    void Start () {
        HP = 3;
        Attackcount = 3;
        Defensecount = 3;
        Specialcount = 3;
    }

    // Update is called once per frame
    void Update() {
    }

}
