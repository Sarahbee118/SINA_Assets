using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchfab : MonoBehaviour
{
    private int killTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        killTimer++;
        if (killTimer >= 40)
        {
            Destroy(gameObject);
        }
    }
}
