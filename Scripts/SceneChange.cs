using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    public void Change() //basic scene change script
    {
        StartCoroutine(ChangeWait());

    }
    IEnumerator ChangeWait()
    {
        yield return null;
        GameObject textbox = GameObject.Find("txtbox");
        while (textbox.activeSelf)
        {
            yield return null;
        }
        SceneManager.LoadScene(scene);
    }
}
