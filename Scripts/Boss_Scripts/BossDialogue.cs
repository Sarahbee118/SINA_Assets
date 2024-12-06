using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDialogue : MonoBehaviour
{
    public Image fadeInOut;
    public txt_trigger firstTime;
    public txt_trigger otherTime;
    // Start is called before the first frame update
    void Start()
    {
        if (SinaManager.Instance.introComplete)
        {
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(0));
            otherTime.TriggerDialogue();
        }
        else
        {
            StartCoroutine(FadeIn());
            firstTime.TriggerDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeIn()
    {
        for (int fadein = 0; fadein < 255; fadein = fadein + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
         
    }
}
