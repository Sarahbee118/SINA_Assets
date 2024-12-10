using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class credits : MonoBehaviour
{
    public GameObject creditsOb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(creditsOb.GetComponent<RectTransform>().anchoredPosition.y);
        if(creditsOb.GetComponent<RectTransform>().anchoredPosition.y > 2699)
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
