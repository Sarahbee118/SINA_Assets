using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.Port;

public class Intro : MonoBehaviour
{
    //public TMP_Text gameBy;
    //public TMP_Text TheStruggle;
    //public TMP_Text names;
    //public TMP_Text controllerRec;
    public TMP_Text screenText;
    public string[] allText;
    public Image[] allImages;
    public Image introImage;
    private int textInt = 0;
    private int imageInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        screenText.color = new Color32(255, 255, 255, 0);
        introImage.color = new Color32(255, 255, 255, 0);
        screenText.text = allText[0];
        introImage = allImages[0];
        StartCoroutine(fadeIn(screenText)); //starts fading in text
        StartCoroutine(fadeInImage(introImage));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fadeIn(TMP_Text currText) //fade in, passes in current text mesh pro
    {
        //currText.text = "Hello";
        for (int opacity = 0; opacity <= 255; opacity += 3) //opacity is from 0 to 255
        {
            currText.color = new Color32(255, 255, 255, System.Convert.ToByte(opacity)); //sets text to be more and more opaque 
            yield return null;
        }

        for (int buffer = 0; buffer < 150; buffer++) {
            yield return null;
        }
        //textInt++;
        if (textInt == 4)
        {
            //SceneManager.LoadScene("Title");
        }
        StartCoroutine(fadeOut(screenText));
        StartCoroutine(fadeOutImage(introImage));

    }

    IEnumerator fadeOut(TMP_Text currText) //fade in, passes in current text mesh pro
    {
        //currText.text = "Hello";
        for (int opacity = 255; opacity >= 0; opacity -= 3) //opacity is from 0 to 255
        {
            currText.color = new Color32(255, 255, 255, System.Convert.ToByte(opacity)); //sets text to be more and more opaque 
            yield return null;
        }

        for (int buffer = 0; buffer < 60; buffer++)
        {
            yield return null;
        }
        textInt++;
        if (textInt != 5)
        {
            screenText.text = allText[textInt];
            StartCoroutine(fadeIn(screenText));
            StartCoroutine(fadeInImage(introImage));
        }
        else
        {
            SceneManager.LoadScene("Title");
        }
        
    }




    IEnumerator fadeInImage(Image currImage) //fade in, passes in current text mesh pro
    {
        //currText.text = "Hello";
        for (int imopacity = 0; imopacity <= 255; imopacity += 5) //opacity is from 0 to 255
        {
            currImage.color = new Color32(255, 255, 255, System.Convert.ToByte(imopacity)); //sets text to be more and more opaque 
            yield return null;
        }

        
    }

    IEnumerator fadeOutImage(Image currImage) //fade in, passes in current text mesh pro
    {
        //currText.text = "Hello";
        for (int imopacity = 255; imopacity >= 0; imopacity -= 4) //opacity is from 0 to 255
        {
            currImage.color = new Color32(255, 255, 255, System.Convert.ToByte(imopacity)); //sets text to be more and more opaque 
            yield return null;
        }
        currImage.color = new Color32(255, 255, 255, 0);

        imageInt++;
        if (imageInt != 5)
        {
            introImage = allImages[imageInt];
            //screenText.text = allText[imageInt];
            //StartCoroutine(fadeIn(screenText));
        }

    }
}
