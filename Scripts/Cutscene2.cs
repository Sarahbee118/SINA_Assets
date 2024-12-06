using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Cutscene2 : MonoBehaviour
{
    public Image fadeInOut;
    public txt_trigger text1;
    public Animator sinamator;
    public GameObject cutSina;
    public GameObject textBox;
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

        for (int fadein = 0; fadein < 255; fadein = fadein + 3)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
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
        SceneManager.LoadScene("BossArena");
    }
    }
