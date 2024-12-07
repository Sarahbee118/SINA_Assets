using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipe : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "enemy")
        {
            enemy.transform.Rotate(0f, 180f, 0f);
        }
    }
}
