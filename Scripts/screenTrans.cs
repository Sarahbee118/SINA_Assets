using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenTrans : MonoBehaviour
{
    public int direction;
    public Rigidbody2D Rigidbody;
    public SpriteRenderer srend;
    // 0 is Right to Left
    // 1 DtU
    // 2 LtR
    // 3 UtD
    // Start is called before the first frame update
    void Start()
    {
       
        switch (direction)
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
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator horTrans ()
    {
        yield return null;
    }
}
