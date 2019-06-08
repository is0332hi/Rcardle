using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartBotton : MonoBehaviour {

    public void SceneLoad()
    {
        SceneManager.LoadScene("ready");
    }

}
