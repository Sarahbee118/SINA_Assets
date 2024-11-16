using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txt_trigger : MonoBehaviour
{
    public txt dialogue;
    public GameObject textbox;
    //public GameObject nextBtn;

    void Start()
    {
        
       // TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        Debug.Log("TriggerDial");
        textbox.SetActive(true);
        FindObjectOfType<txtmanager>().StartDialogue(dialogue);
    }

    public void NextDialogue()
    {
        FindObjectOfType<txtmanager>().DisplayNextSentence();
    }    

}
