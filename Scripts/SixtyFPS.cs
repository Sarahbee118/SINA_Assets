using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixtyFPS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.currentResolution.refreshRate);
        Application.targetFrameRate = 60;

        if (Screen.currentResolution.refreshRate == 120)
        {
            QualitySettings.vSyncCount = 2;
        }
        else if (Screen.currentResolution.refreshRate == 60)
        {
            QualitySettings.vSyncCount = 1;
        }

       // if (Resolution.refreshRateRatio == 120) ;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
