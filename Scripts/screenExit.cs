using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class screenExit : MonoBehaviour
{
    public string exitDirection;
    public string newScene;
    public GameObject trans;
    public bool cinemachineExit = false;
    private Vector3 spawnLocation;
    public Camera camera;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {
        DontDestroyOnLoad(parent); //so it stays 
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Sina>() != null)
        {
            GameObject transition = Instantiate < GameObject >(trans, transform.position, Quaternion.identity);
            
            if (exitDirection == "left")
            {
                //Screen.width-1, Screen. 
                transition.transform.position = new Vector3(27f, 0f, 0f);
                
                    
                
            }
            else if (exitDirection == "right")
            {
                spawnLocation = camera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0));
                transition.transform.position = new Vector3(spawnLocation.x - 27f, spawnLocation.y, 0f);
            }
            else if (exitDirection == "up")
            {

            }
            else if (exitDirection == "down")
            {

            }
            // trans.SetActive(true);
            StartCoroutine(loadBuffer(transition));

        }
    }

    IEnumerator loadBuffer(GameObject transition)
    {
        for (int i = 0; i < 17; i++)
        {
            yield return null;
        }
        SinaManager.Instance.currScreen = newScene;
        SinaManager.Instance.screenExit = exitDirection;
        
        SceneManager.LoadScene(newScene);
        for (int i = 0; i < 1; i++)
        {
            yield return null;
        }

        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (SinaManager.Instance.screenExit == "left")
        {
            //Screen.width-1, Screen. 
            transition.transform.position = new Vector3(27f, 0f, 0f);



        }
        else if (SinaManager.Instance.screenExit == "right")
        {
            spawnLocation = camera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0));
            transition.transform.position = new Vector3(transition.transform.position.x, spawnLocation.y, 0f);
        }
        else if (SinaManager.Instance.screenExit == "up")
        {

        }
        else if (SinaManager.Instance.screenExit == "down")
        {

        }
        //Destroy(gameObject);
    }
}
