using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressStart : MonoBehaviour
{
    public TMP_Text pressStart;
    private int blinktimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (blinktimer > 90)
        {
            blinktimer = 0;
            if (pressStart.color.a == 255)
            {
                pressStart.color = new Color(pressStart.color.r, pressStart.color.g, pressStart.color.b, 0f);
            }
            else
            {
                pressStart.color = new Color(pressStart.color.r, pressStart.color.g, pressStart.color.b, 255f);
            }
        }
        blinktimer++;

    }
}
