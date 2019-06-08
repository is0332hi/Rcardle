using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameoverbotton : MonoBehaviour {

    public void gbottondown()
    {
        SceneManager.LoadScene("title");
    }

}
