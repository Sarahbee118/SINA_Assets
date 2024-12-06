using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    
    public txt_trigger firstTime;
  
    // Start is called before the first frame update
    void Start()
    {
        if (SinaManager.Instance.introComplete)
        {
          
        }
        else
        {
            SinaManager.Instance.introComplete = true;    
            firstTime.TriggerDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
