using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour
{

    public enum Nextaction
    {
        Charge,
        Attack,
        Down,

        None
    }

    private float speed = 0.05f;
    public static Nextaction nextaction;

    // Use this for initialization
    void Start()
    {
        nextaction = Nextaction.None;
    }

    public void startmove()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, 2.5f), speed);
    }


    public void enemyaction()
    {
        switch (nextaction)
        {
            case Nextaction.Charge:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, 3.0f), speed);
                if (transform.position == new Vector3(-5, 3.0f))
                {
                    nextaction = Nextaction.Attack;
                }
                break;
            case Nextaction.Attack:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, -1.5f), speed * 5);
                if (transform.position == new Vector3(-5, -1.5f))
                {
                    nextaction = Nextaction.Down;
                }
                break;
            case Nextaction.Down:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, 2.5f), speed * 5);
                if (transform.position == new Vector3(-5, 2.5f))
                {
                    nextaction = Nextaction.None;
                    scenemanager.enemyactionnumber = 2;
                }
                break;
        }
    }
}