using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypt2 : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    public Transform bulletpos;



    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        //if sina is 8f or less away from the enemy - enemy follows her

        float distance = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log(distance);

        // if sina is 6f or less away from enemy they start shooting
        if(distance < 6)
        {
            timer += Time.deltaTime;

            if (timer > 3)
            {
                timer = 0;
                Shooting();
            }
        }

    }

    void Shooting()
    {
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
    }

}
