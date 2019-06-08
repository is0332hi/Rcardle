using UnityEngine;
using System.Collections;

public class MainSoundScript : MonoBehaviour
{

    public bool dontDestroyEnabled = true;

    private static MainSoundScript instance = null;

    public static MainSoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}

