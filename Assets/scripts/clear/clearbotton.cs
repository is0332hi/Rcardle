using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class clearbotton : MonoBehaviour {

    public void cbottondown()
    {
        SceneManager.LoadScene("title");
    }
}
