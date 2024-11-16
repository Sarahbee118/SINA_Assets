using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenTrans : MonoBehaviour //Yeets an arrow across the screen
{
    public int direction;
    public Rigidbody2D Rigidbody;
    public SpriteRenderer srend;
    private int killtimer;

    // 0 is Right to Left
    // 1 DtU
    // 2 LtR
    // 3 UtD
    // Start is called before the first frame update
    void Start()
    {
        killtimer = 0; //so it doesn't stay loaded forever
        switch (direction) //which direction it flies
        {
            case 0:
                srend.flipX = false;
                Rigidbody.velocity = new Vector2(-100f, 0f);
                break;

            case 1:
                break;

            case 2:
                srend.flipX = true;
                Rigidbody.velocity = new Vector2(100f, 0f);
                break;

            case 3:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        killtimer += 1;
        if (killtimer > 120) //dies after 2 seconds
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //so it stays 
    }

    IEnumerator horTrans ()
    {
        yield return null;
    }
}
