using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack3 : MonoBehaviour
{
    public BossHeader bossHeader;
    public BossStateMachine stateMachine;
    public Transform masterSpark;
    public int startHealth;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(Attack());
        BossStateMachine stateMachine = GetComponent<BossStateMachine>();
        BossHeader bossHeader = GetComponent<BossHeader>();
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
        startHealth = SinaManager.Instance.SinaHealth;
        Debug.Log(startHealth);
        //bossHeader.banimator.Play("Boss_Warpout");
        for (int windup = 0; windup < 20; windup++)
        {
            yield return null;
        }
        transform.position = new Vector2(sina.transform.position.x, -4f);
        bossHeader.banimator.Play("Boss_WarpIn");
        for (int windup = 0; windup < 24; windup++)
        {
            yield return null;
        }
        bossHeader.banimator.Play("Boss_Fire");
        for ( int windup = 0; windup < 90; windup++)
        {
            transform.position = new Vector2(sina.transform.position.x, -4f);
            // transform.position.y = -3f;
            
            yield return null;
        }
        BoxCollider2D sparkCollision = GetComponentInChildren<BoxCollider2D>();
        //GameObject self = GameObject.Find("Boss");
        //Transform masterSpark = this.transform.Find("MasterSPARK");
        for (int firing = 0; firing < 26; firing++) 
        {
            masterSpark.transform.position = new Vector2(this.transform.position.x,masterSpark.transform.position.y-.5f);
            //sparkCollision.size = new Vector2(sparkCollision.size.x + 1f, 6.75f);
            if (SinaManager.Instance.SinaHealth < startHealth)
            {
                Debug.Log("Ouch");
                masterSpark.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1f);
                //transform.position = bossHeader.home;
                stateMachine.attackFrame = 0;
                stateMachine.state = 0;
                StopAllCoroutines();
            }


                yield return null;
        }

        for (int casting = 0; casting < 300; casting++) 
        {
            Debug.Log(startHealth);
            Debug.Log(SinaManager.Instance.SinaHealth);
            Debug.Log(startHealth < SinaManager.Instance.SinaHealth);
            if (SinaManager.Instance.SinaHealth < startHealth)
            {
                Debug.Log("Ouch");
                masterSpark.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1f);
                //transform.position = bossHeader.home;
                stateMachine.attackFrame = 0;
                stateMachine.state = 0;
                StopAllCoroutines();


            }
            if (casting < 30)
            {
                //sparkCollision.size = new Vector2(sparkCollision.size.x + .5f, 6.75f);
            }
            
            if (startHealth > SinaManager.Instance.SinaHealth)
            {
                Debug.Log("Ouch");
                masterSpark.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1f);
                //transform.position = bossHeader.home;
                stateMachine.attackFrame = 0;
                stateMachine.state = 0;
                StopAllCoroutines();

            }
            //Debug.Log(casting);
            float distance = Vector2.Distance(transform.position, sina.transform.position);
            transform.position = Vector2.MoveTowards(this.transform.position, sina.transform.position, 17f*Time.deltaTime);
            transform.position = new Vector2(this.transform.position.x, -4f);
            masterSpark.transform.position = new Vector2(this.transform.position.x, masterSpark.transform.position.y);
            yield return null;
        }
        for (int defiring = 0; defiring < 26; defiring++)
        {
                if (startHealth > SinaManager.Instance.SinaHealth)
                {
                    Debug.Log("Ouch");
                    masterSpark.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1f);
                    //transform.position = bossHeader.home;
                    stateMachine.attackFrame = 0;
                    stateMachine.state = 0;
                    StopAllCoroutines();

                }
                masterSpark.transform.position = new Vector2(masterSpark.transform.position.x, masterSpark.transform.position.y - .5f);
            //sparkCollision.size = new Vector2(sparkCollision.size.x + 1f, 6.75f);

            yield return null;
        }
        masterSpark.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1f);
        //transform.position = bossHeader.home;
        stateMachine.attackFrame = 0;
        stateMachine.state = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit!");
        //StopAllCoroutines();
        //Transform masterSpark = this.transform.Find("MasterSPARK");
       
    }

    }
