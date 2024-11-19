using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        Debug.Log(SinaManager.Instance.currScreen);
        SinaManager.Instance.currScreen = SinaManagerSaved.Instance.currScreen;
        Debug.Log(SinaManager.Instance.currScreen);
        //SceneManager.LoadScene(SinaManager.Instance.currScreen);
    }
}
