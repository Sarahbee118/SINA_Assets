using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int killTimer = 0; // Auto Despawn the bullet
                               // Start is called before the first frame update
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int attackDamage = 15;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        killTimer++;
       if (killTimer >= 120) //despawns after 2 seconds. 
       {
            //gameObject.SetActive(false);
            Destroy(gameObject);
       }
        else
        {
            //copied from punch
            Collider2D[] personalSpace = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D thing in personalSpace)
            {
                if (thing.GetComponent<enemy>() != null)
                {

                    //if (punchPower = false)
                    //{

                    thing.GetComponent<enemy>().TakeDamage(attackDamage);
                    Debug.Log("BulletWorked");
                    Destroy(gameObject);


                    //moveLock = false;
                }
                if (thing.GetComponent<BossHeader>() != null)
                {
                    thing.GetComponent<BossHeader>().TakeDamage(attackDamage);
                    Debug.Log("BulletWorked");
                    Destroy(gameObject);
                }
                if (thing.GetComponent<target>() != null) 
                {
                    thing.gameObject.SetActive(false);
                    Destroy(gameObject);
                }
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
