using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ending : MonoBehaviour
{
    public Image fadeInOut;
    public txt_trigger text1;
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
        text1.TriggerDialogue();

        while (textBox.activeSelf)
        {
            yield return null;
        }

        for (float fadein = 0; fadein < 255; fadein = fadein + 1f)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(255 - fadein));
        }
        yield return new WaitForSeconds(10);

        for (int fadeout = 0; fadeout < 255; fadeout = fadeout + 1)
        {
            yield return null;
            fadeInOut.color = new Color32(0, 0, 0, System.Convert.ToByte(fadeout));
        }
        SceneManager.LoadScene("Title");
    }
}
