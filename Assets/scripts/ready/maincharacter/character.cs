using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

    public enum Nextaction
    {
        Charge,
        Attack,
        Down,

        None
    }
    
    public static Nextaction nextaction;
    private float speed = 0.05f;

    // Use this for initialization
    void Start()
    {
        nextaction = Nextaction.None;
    }

    // Update is called once per frame
    public void startmove()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, -2.5f), speed);
    }

    public void resultmove()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, 2.5f), speed);
    }

    public void endmove()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, 7f), speed);

    }

    public void characteraction()
    {
        switch (nextaction) {
            case Nextaction.Charge:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, -3.0f), speed);
                if (transform.position == new Vector3(-5, -3.0f))
                {
                    nextaction = Nextaction.Attack;
                }
                break;
            case Nextaction.Attack:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, 1.5f), speed * 5);
                if (transform.position == new Vector3(-5, 1.5f))
                {
                    nextaction = Nextaction.Down;
                }
                break;
            case Nextaction.Down: 
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5, -2.5f), speed * 5);
                if (transform.position == new Vector3(-5, -2.5f))
                {
                    nextaction = Nextaction.None;
                    scenemanager.maincharacteractionnumber = 2;
                }
                break;
        }
    }
}
