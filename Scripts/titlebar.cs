using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlebar : MonoBehaviour
{
    public TMP_Text sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
