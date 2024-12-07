using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene1 : MonoBehaviour
{
    public GameObject textBox;
   
    public GameObject roomScene;
    public GameObject officeScene;
    public GameObject roomEScene;
    public txt_trigger text1;
    public txt_trigger text2;
    public txt_trigger text3;
    public txt_trigger text4;
    public txt_trigger text5;
    public txt_trigger text6;
    public txt_trigger text7;
    public txt_trigger text8;
    public txt_trigger text9;
    public txt_trigger text10;
    public txtmanager textManager;
    public Image fadeInOut;
    public GameObject sinaBedSleep;
    public GameObject sinaBedAwake;
    public GameObject sinaNextToBed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Cutscene()
    {
        sinaBedSleep.SetActive(true);
        sinaBedAwake.SetActive(false);
        for (int fadein = 0; fadein < 255; fadein = fadein+ 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255-fadein));
        }
        text1.TriggerDialogue();
        sinaBedAwake.SetActive(true);
        sinaBedSleep.SetActive(false);
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        sinaBedSleep.SetActive(true);
        sinaBedAwake.SetActive(false);
        roomScene.SetActive(false);
        officeScene.SetActive(true);
        for (int fadein = 0; fadein < 255; fadein = fadein + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        text2.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        officeScene.SetActive(false);
        roomEScene.SetActive(true);
        for (int fadein = 0; fadein < 255; fadein = fadein + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        text3.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        roomEScene.SetActive(false);
        roomScene.SetActive(true);


        //Loop 2
        textManager.textSpeed = .01f;
        sinaBedSleep.SetActive(true);
        sinaBedAwake.SetActive(false);
        for (int fadein = 0; fadein < 255; fadein = fadein + 5)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        sinaBedAwake.SetActive(true);
        sinaBedSleep.SetActive(false);
        text4.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 5)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        roomScene.SetActive(false);
        officeScene.SetActive(true);
        for (int fadein = 0; fadein < 255; fadein = fadein + 5)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        text5.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 5)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        officeScene.SetActive(false);
        roomEScene.SetActive(true);
        for (int fadein = 0; fadein < 255; fadein = fadein + 5)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        text6.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout +5)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }

        roomEScene.SetActive(false);
        roomScene.SetActive(true);

        //Loop 3
        textManager.textSpeed = .005f;
        sinaBedSleep.SetActive(true);
        sinaBedAwake.SetActive(false);
        for (int fadein = 0; fadein < 255; fadein = fadein + 10)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        sinaBedAwake.SetActive(true);
        sinaBedSleep.SetActive(false);
        text7.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 10)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        roomScene.SetActive(false);
        officeScene.SetActive(true);
        for (int fadein = 0; fadein < 255; fadein = fadein + 10)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        text8.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 10)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        officeScene.SetActive(false);
        roomEScene.SetActive(true);
        for (int fadein = 0; fadein < 255; fadein = fadein + 10)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        text9.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 10)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        roomEScene.SetActive(false);
        roomScene.SetActive(true);


        //Loop 4-6


        for (int i  = 1; i <= 3; i++)
        {
            sinaBedSleep.SetActive(true);
            sinaBedAwake.SetActive(false);
            textManager.textSpeed = .02f;
            for (int fadein = 0; fadein < 255; fadein = fadein + 10+(3*i))
            {
                yield return null;
                fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
            }
            sinaBedAwake.SetActive(true);
            sinaBedSleep.SetActive(false);
            // text7.TriggerDialogue();
            while (textBox.activeSelf)
            {
                yield return null;
            }
            for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 10 + (3 * i))
            {
                yield return null;
                fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
            }
            roomScene.SetActive(false);
            officeScene.SetActive(true);
            for (int fadein = 0; fadein < 255; fadein = fadein + 10 + (3 * i))
            {
                yield return null;
                fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
            }
           // text8.TriggerDialogue();
            while (textBox.activeSelf)
            {
                yield return null;
            }
            for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 10 + (3 * i))
            {
                yield return null;
                fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
            }
            officeScene.SetActive(false);
            roomEScene.SetActive(true);
            for (int fadein = 0; fadein < 255; fadein = fadein + 10 + (3 * i))
            {
                yield return null;
                fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
            }
           // text9.TriggerDialogue();
            while (textBox.activeSelf)
            {
                yield return null;
            }
            for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 10 + (3 * i))
            {
                yield return null;
                fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
            }
            roomEScene.SetActive(false);
            roomScene.SetActive(true);
            yield return null; 
        }
        for (int fadein = 0; fadein < 255; fadein = fadein + 19)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        sinaBedAwake.SetActive(false);
        sinaBedSleep.SetActive(false);
        sinaNextToBed.SetActive(true);
        text10.TriggerDialogue();
        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255));
        SceneManager.LoadScene("Cutscene2");
    }
}
