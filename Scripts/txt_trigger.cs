using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txt_trigger : MonoBehaviour
{
    public txt dialogue;
    public GameObject textbox;
    public AudioClip hi;
    //public GameObject nextBtn;

    void Start()
    {
        
       // TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        Debug.Log("TriggerDial");
        textbox.SetActive(true);
        if (hi != null)
        {
         //   AudioSource.PlayClipAtPoint(hi, transform.position);
        }
        FindObjectOfType<txtmanager>().StartDialogue(dialogue);
    }

    public void NextDialogue()
    {
        FindObjectOfType<txtmanager>().DisplayNextSentence();
    }    

}
