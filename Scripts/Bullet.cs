using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int killTimer = 0; // Auto Despawn the bullet
    // Start is called before the first frame update
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
    }
}
