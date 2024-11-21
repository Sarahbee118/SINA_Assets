using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove : MonoBehaviour
{
    public Sina sina;
    public GameObject reveal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reveal()
    {
        StartCoroutine(revealWait());
    }

    IEnumerator revealWait()
    {
        yield return null;
        GameObject textbox = GameObject.Find("txtbox");
        while (textbox.activeSelf)
        {
            yield return null;
        }

        reveal.SetActive(false);
    }
}
