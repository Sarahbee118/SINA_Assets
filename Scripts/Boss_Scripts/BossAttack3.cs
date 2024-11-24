using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack3 : MonoBehaviour
{
    public BossHeader bossHeader;
    public BossStateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackTrigger()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        GameObject sina = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector2(0f, -4f);
        for ( int windup = 0; windup < 90; windup++)
        {
            transform.position = new Vector2(sina.transform.position.x, -3f);
           // transform.position.y = -3f;
            yield return null;
        }
        BoxCollider2D sparkCollision = GetComponentInChildren<BoxCollider2D>();
        GameObject self = GameObject.Find("Boss");
        Transform masterSpark = this.transform.Find("MasterSpark");
        for (int firing = 0; firing < 26; firing++) 
        {
            masterSpark.transform.position = new Vector2(masterSpark.transform.position.x,masterSpark.transform.position.y-.5f);
            //sparkCollision.size = new Vector2(sparkCollision.size.x + 1f, 6.75f);
            
            yield return null;
        }

        for (int casting = 0; casting < 600; casting++) 
        {
            if (casting < 30)
            {
                //sparkCollision.size = new Vector2(sparkCollision.size.x + .5f, 6.75f);
            }
            Debug.Log(casting);
            float distance = Vector2.Distance(transform.position, sina.transform.position);
            transform.position = Vector2.MoveTowards(this.transform.position, sina.transform.position, 17f*Time.deltaTime);
            transform.position = new Vector2(this.transform.position.x, -4f);
            yield return null;
        }
        for (int defiring = 0; defiring < 26; defiring++)
        {
            masterSpark.transform.position = new Vector2(masterSpark.transform.position.x, masterSpark.transform.position.y - .5f);
            //sparkCollision.size = new Vector2(sparkCollision.size.x + 1f, 6.75f);

            yield return null;
        }
        transform.position = bossHeader.home;
        stateMachine.attackFrame = 0;
        stateMachine.state = 0;
    }

    }
