using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameBy : MonoBehaviour
{
    public TMP_Text aGameBy;
    public TMP_Text TheStruggle;
    public TMP_Text names;
    public TMP_Text controllerRec;
    public TMP_Text buffer;
    public int textInt = -1;
    // Start is called before the first frame update
    void Start()
    {
        aGameBy.color = new Color32(255, 255, 255, 0); //0 in alpha sets them to transparent
        TheStruggle.color = new Color32(255, 255, 255, 0);
        names.color = new Color32(255, 255, 255, 0);
        controllerRec.color = new Color32(255, 255, 255, 0);
        // gameBy.faceColor = new Color32(255, 255, 255, 0);
        int nameOrder = Random.Range(0, 3);
        switch (nameOrder) //for fairness
        {
            case 0:
                names.text = "aka<br>Sarah Rigg,<br>Bella Donatelli,<br>and Liana Bourdon"; //<br> is line break
                break;
            case 1:
                names.text = "aka<br>Bella Donatelli,<br>Liana Bourdon,<br>and Sarah Rigg";
                break;
            case 2:
                names.text = "aka<br>Liana Bourdon,<br>Sarah Rigg,<br>and Bella Donatelli";
                break;
        }
        
        StartCoroutine(fadeIn(aGameBy)); //starts fading in text
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
        textInt++;

        switch (textInt) //switches to next text to fade in
        {
            case 0:
                StartCoroutine(fadeIn(TheStruggle));
                break;
            case 1:
                StartCoroutine(fadeIn(names));
                break;
            case 2:
                StartCoroutine(fadeIn(controllerRec));
                break;
            case 3:
                StartCoroutine(fadeIn(buffer));
                break;
            case 4:
               // SceneManager.LoadScene("Title"); //load title screen
               StartCoroutine(fadeOut(aGameBy));
               StartCoroutine(fadeOut(TheStruggle));
                StartCoroutine(fadeOut(names));
                StartCoroutine(fadeOut(controllerRec));

                break;
        }
    }

    IEnumerator fadeOut(TMP_Text currText) //fade in, passes in current text mesh pro
    {
        //currText.text = "Hello";
        for (int opacity = 255; opacity >= 0; opacity -= 3) //opacity is from 0 to 255
        {
            currText.color = new Color32(255, 255, 255, System.Convert.ToByte(opacity)); //sets text to be more and more opaque 
            yield return null;
        }

        for (int buffer = 0; buffer < 120; buffer++)
        {
            yield return null;
        }
        
        SceneManager.LoadScene("Intro");
        

    }

}
