using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    public txt_trigger trigger; //trigger text box
    public GameObject TextBox; //the textbox itself
    //public bool moveLock = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Interact()
    {
     /*   Debug.Log("Interact");
        if (TextBox.activeSelf == true)
        {
            trigger.NextDialogue();
            if (TextBox.activeSelf == false)
            {
                //moveLock = false;
            }

        }
        else
        {
            TextBox.SetActive(true);
            trigger.TriggerDialogue();
            //moveLock = true;
            Debug.Log("line one of text");
        }
     */
    }
}
