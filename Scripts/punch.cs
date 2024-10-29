using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.7f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    private int killTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] personalSpace = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D thing in personalSpace)
        {
            if (thing.GetComponent<enemy>() != null)
            {

                //if (punchPower = false)
                //{

                thing.GetComponent<enemy>().TakeDamage(attackDamage);
                Debug.Log("PunchWorked");



                //moveLock = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        killTimer++;
        if (killTimer >= 15)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
