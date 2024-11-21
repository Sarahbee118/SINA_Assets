using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public GameObject thing; 
    public GameObject reveal;




    //once sina comes into enemy personal space - they follow her and shoot in her direction
    //bullet direction changes based on enemy direction
    //update to see who interacts with personal space
    //once triggered - update follows with vector3

    // Start is called before the first frame update
    void Start()
    {     
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //hurt animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy dead");

        if (thing == null && reveal == null)
        {
            Destroy(gameObject);
        }
        else if (thing == null)
        {
            reveal.SetActive(false);
            Destroy(gameObject);
        }
        else if (reveal == null)
        {
            thing.SetActive(true);
            Destroy(gameObject);
        }
        else if (reveal != null && thing != null)
        {
            reveal.SetActive(false);
            thing.SetActive(true);
            Destroy(gameObject);
        }

        //die animation
    }



}
