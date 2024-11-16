using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screnEnter : MonoBehaviour
{
    public string enterLocation;
    private string exitLocation;
    public GameObject Sina;
    // Start is called before the first frame update
    void Start()
    {
        if (SinaManager.Instance.screenExit != null) //so it doesn't error
        {
            exitLocation = SinaManager.Instance.screenExit; //checks what direction you exited the last screen from
            Sina = GameObject.Find("Sina (Player)"); //find player
            if (enterLocation == "left" && exitLocation == "right") //so only the correct combo of entrace and where exited moves Sina
            {
                Debug.Log("A");
                Sina.transform.position = transform.position;
            }
            else if (enterLocation == "right" && exitLocation == "left")
            {
                Debug.Log("B");
                Sina.transform.position = transform.position;
            }
            else if (enterLocation == "up" && exitLocation == "down")
            {
                Debug.Log("C");
                Sina.transform.position = transform.position;
            }
            else if (enterLocation == "down" && exitLocation == "up")
            {
                Debug.Log("D");
                Sina.transform.position = transform.position;
            }
        }
        else
        {
           // exitLocation = "bottom";
        }
        //Debug.Log(exitLocation);
        //Debug.Log(enterLocation);
        //Debug.Log(enterLocation == "down" && enterLocation == "up");
        
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
