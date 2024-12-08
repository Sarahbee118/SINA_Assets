using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene3 : MonoBehaviour
{
    public Image fadeInOut;
    public txt_trigger text1;
    public txt_trigger text2;
    public GameObject textBox;
    public Animator sinthamator;
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
        sinthamator.Play("Boss_Punch");
        for (int fadein = 0; fadein < 255; fadein = fadein + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        sinthamator.Play("Boss_Reveal");
        yield return new WaitForSeconds(1);
        sinthamator.Play("Sinthia");
        text1.TriggerDialogue();

        while (textBox.activeSelf)
        {
            yield return null;
        }
        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        text2.TriggerDialogue();

        while (textBox.activeSelf)
        {
            yield return null;
        }
        SceneManager.LoadScene("credits");

    }
}