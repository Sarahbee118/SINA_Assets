using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int timeCounter = -30;
    public float yPos;
  //  public float stepCounter = -10.5f;
    public GameObject spikefab;
    public SpriteRenderer testRend;
    public Animator animator;
    public BoxCollider2D boxCol;


    // Start is called before the first frame update
#pragma warning disable IDE0051 // Remove unused private members
    void Start()
#pragma warning restore IDE0051 // Remove unused private members
    {
        //boxCol.enabled = false;   
    }

    // Update is called once per frame
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
    void Update()
    {
        if (Time.timeScale != 0f)
        {


            timeCounter += 1;
            if (timeCounter == 15)
            {
                // testRend.color = new Color(0, 0, 0);
                animator.Play("SpikesPop", 0, 0);
                boxCol.enabled = true;
            }
            if (timeCounter == 30)
            {
                // stepCounter += 1;

                GameObject nextSpike = Instantiate<GameObject>(spikefab, transform.position, Quaternion.identity);
                nextSpike.transform.position = new Vector2(this.transform.position.x + 1f, transform.position.y);
                nextSpike.GetComponent<Spikes>().timeCounter = 0;
                //nextSpike.GetComponent<Spikes>().testRend.color = Color.white;
                nextSpike.GetComponent<Spikes>().animator.Play("SpikeDefault", 0, 0);
                nextSpike.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (timeCounter == 45)
            {
                animator.Play("SpikeDefault", 0, 0);
                boxCol.enabled = false;
            }
            if (timeCounter > 60 || this.transform.position.x > 11)
            {
                Destroy(gameObject);
            }
        }
    }
}
