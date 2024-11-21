using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class saveload : MonoBehaviour
{
    private GameObject Sina;
    // Start is called before the first frame update
    void Start()
    {
     //  Save();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        

        //
    }
    public void Save() 
    {

        Sina = GameObject.FindGameObjectWithTag("Player");
        Sina.GetComponent<Sina>().AmmoRefill();
        Sina.GetComponent<Sina>().HealthRefill();
        string savefile = JsonUtility.ToJson(SinaManager.Instance);
        Debug.Log(Application.dataPath);
        File.WriteAllText(Application.dataPath + "/Sina.si", savefile);

    }              
}
