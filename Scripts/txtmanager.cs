using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class txtmanager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;
    public float textSpeed;
    private string sentence;
    public AudioClip talkingbeep;
    public AudioClip startClick;
    //public AudioClip hi;

    // Start is called before the first frame update
    void Start()
    {
        
     
    }

    public void StartDialogue (txt dialogue)
    {
        AudioSource.PlayClipAtPoint(startClick, new Vector3(0f,0f,0f));
        sentences = new Queue<string>();
        Debug.Log ("start coversation with " + dialogue.name);
        nameText.text = dialogue.name + ":";
        if (nameText.text == "Game:")
        {
            nameText.text = " ";
        }
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            Debug.Log("A");
        }

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence()
    {
        Debug.Log(sentences);
        Debug.Log(sentences.Count);
       
        if (dialogueText.text == sentence ^ sentence == null)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            dialogueText.text = string.Empty;

            sentence = sentences.Dequeue();
            
            if (sentence.Length > 8)
            {
                //Debug.Log(sentence.Substring(0, 8));
                //Debug.Log(sentence.Substring(8));
                if (sentence.Substring(0, 8) == "newName:")
                {
                    nameText.text = sentence.Substring(8) + ":";
                    sentence = sentences.Dequeue();
                }
                if (nameText.text == "Game:")
                {
                    nameText.text = " ";
                }
                if (sentence.Substring(0, 7) == "You got" || sentence.Substring(0, 8) =="Lilith s")
                {
                    Debug.Log("Dudududahhhhh");
                    //AudioSource.PlayClipAtPoint(hi, transform.position); //audioclip
                }
            }
            StartCoroutine(TypeLine(sentence));
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = sentence;
        }

        
        

        


        //Debug.Log(sentence);

        void EndDialogue()
        {
            Debug.Log("end of convo");
            gameObject.SetActive(false);
        }        
    }

    IEnumerator TypeLine(string currLine)
    {
        foreach (char c in currLine)
        {
            AudioSource.PlayClipAtPoint(talkingbeep, new Vector3(0f,0f,0f));
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
