using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.Port;

public class OpeningCutscene1 : MonoBehaviour
{
    public GameObject textBox;
    public GameObject actor1;
    public GameObject appartmentBackgroundDay;
    public GameObject appartmentBackgroundNight;
    public GameObject officeBackground;
    public txt_trigger dialogue1;
    public txt_trigger dialogue2;
    public txt_trigger dialogue3;
    public int cutsceneTracker;
    public Image fadeBlack;


    // Start is called before the first frame update
    void Start()
    {
        fadeBlack.color = new Color32(0, 0, 0, 0);
        StartCoroutine(cutsceneScript());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timebuffer(int bufferframes)
    {
        for (int buffer = 0; buffer < bufferframes; buffer++)
        {
            yield return null;
        }
    }

    IEnumerator cutsceneScript()
    {
        Debug.Log("Begin");
        Debug.Log("Alarm SFX");
        appartmentBackgroundDay.SetActive(true);
        for (int opacity = 255; opacity >= 0; opacity -= 5) //opacity is from 0 to 255
        {
            fadeBlack.color = new Color32(0, 0, 0, System.Convert.ToByte(opacity)); //sets text to be more and more opaque 
            yield return null;
        }
        
        //yield return new WaitForSeconds(2);
        Debug.Log("Sina Alarm Off Anim");
        
        textBox.SetActive(true);
        dialogue1.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        Debug.Log("After");
        for (int opacity = 0; opacity <= 255; opacity += 5) //opacity is from 0 to 255
        {
            fadeBlack.color = new Color32(0, 0, 0, System.Convert.ToByte(opacity)); //sets text to be more and more opaque 
            yield return null;
        }
        appartmentBackgroundDay.SetActive(false);
        officeBackground.SetActive(true);
        yield return new WaitForSeconds(.5f);
        for (int opacity = 255; opacity >= 0; opacity -= 5) //opacity is from 0 to 255
        {
            fadeBlack.color = new Color32(0, 0, 0, System.Convert.ToByte(opacity)); //sets text to be more and more opaque 
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        textBox.SetActive(true);
        dialogue2.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int opacity = 0; opacity <= 255; opacity += 5) //opacity is from 0 to 255
        {
            fadeBlack.color = new Color32(0, 0, 0, System.Convert.ToByte(opacity)); //sets text to be more and more opaque 
            yield return null;
        }
        appartmentBackgroundNight.SetActive(true);
        officeBackground.SetActive(false);
        yield return new WaitForSeconds(.5f);
        for (int opacity = 255; opacity >= 0; opacity -= 5) //opacity is from 0 to 255
        {
            fadeBlack.color = new Color32(0, 0, 0, System.Convert.ToByte(opacity)); //sets text to be more and more opaque 
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        textBox.SetActive(true);
        dialogue3.TriggerDialogue();
    }
}
