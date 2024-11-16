using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class interact : MonoBehaviour
{
    public Transform interactPoint;
    public float interactRange = 0.7f;
    public LayerMask npcLayers;
    
    
    private int killTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] personalSpace = Physics2D.OverlapCircleAll(interactPoint.position, interactRange, npcLayers);
        foreach (Collider2D thing in personalSpace)
        {
            if (thing.GetComponent<npc>() != null & thing.GetComponent<txt_trigger>() != null) 
            {

                //if (punchPower = false)
                //{
                Debug.Log("Interacted");
                thing.GetComponent<txt_trigger>().TriggerDialogue(); //extra things it can do
                if (thing.GetComponent<GiveItem>() != null)
                {
                    thing.GetComponent<GiveItem>().ItemGet();
                }
                if (thing.GetComponent<SceneChange>() != null)
                {
                    thing.GetComponent<SceneChange>().Change();
                }



                //moveLock = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        killTimer++;
        if (killTimer >= 20)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (interactPoint == null)
            return;

        Gizmos.DrawWireSphere(interactPoint.position, interactRange);
    }
}