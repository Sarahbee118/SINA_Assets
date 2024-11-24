using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : MonoBehaviour
{
    public GameObject bulletfab;
    public BossHeader bossHeader;
    public BossStateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        
       // StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AttackTrigger()
    {
        Debug.Log("Attack Triggered");
        StartCoroutine(Attack());
    }
    public IEnumerator Attack()
    {

        int[] attackOrder = { 0, 1, 2 };
        for (int t = 0; t < attackOrder.Length; t++) //
        {
            int tmp = attackOrder[t];
            int r = Random.Range(t, attackOrder.Length);
            attackOrder[t] = attackOrder[r];
            attackOrder[r] = tmp;
        }
        BossStateMachine stateMachine = GetComponent<BossStateMachine>();
        Vector3[] teleportLocations = new Vector3[] { new Vector3(0, -4.5f, 0f), new Vector3(-7.5f, -5.5f, 0f), new Vector3(7.5f, -5.5f, 0f) };

        for (int timesAttack = 0; timesAttack <= 2; timesAttack++)
        {
            for (int windup = 0; windup < 15; windup++)
            {
                yield return null;
            }
            transform.position = teleportLocations[attackOrder[timesAttack]];
            for (int windup = 0; windup < 30; windup++)
            {
                yield return null;
            }
            GameObject bullet1 = Instantiate<GameObject>(bulletfab, transform.position, Quaternion.identity);
            GameObject bullet2 = Instantiate<GameObject>(bulletfab, transform.position, Quaternion.identity);
            GameObject bullet3 = Instantiate<GameObject>(bulletfab, transform.position, Quaternion.identity);
            GameObject bullet4 = Instantiate<GameObject>(bulletfab, transform.position, Quaternion.identity);
            GameObject bullet5 = Instantiate<GameObject>(bulletfab, transform.position, Quaternion.identity);

            bullet1.transform.Rotate(00.0f, 0.0f, 90.0f, 0f);
            bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sin(30 * Mathf.Deg2Rad) * -20, (Mathf.Cos(-30 * Mathf.Deg2Rad)) * -20);
            bullet2.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sin(30 * Mathf.Deg2Rad) * 20, (Mathf.Cos(-30 * Mathf.Deg2Rad)) * -20);
            bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sin(15 * Mathf.Deg2Rad) * -20, (Mathf.Cos(-15 * Mathf.Deg2Rad)) * -20);
            bullet4.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sin(15 * Mathf.Deg2Rad) * 20, (Mathf.Cos(-15 * Mathf.Deg2Rad)) * -20);
            bullet5.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sin(0 * Mathf.Deg2Rad) * 20, (Mathf.Cos(0 * Mathf.Deg2Rad)) * -20);
            Debug.Log(bullet3.GetComponent<Rigidbody2D>().velocity);
            Debug.Log(bullet5.GetComponent<Rigidbody2D>().velocity);

        }
        transform.position = bossHeader.home;
        stateMachine.attackFrame = 0;
        stateMachine.state = 0;



    }
}

        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
       
        
   
