using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack4 : MonoBehaviour
{
    public BossHeader bossHeader;
    public BossStateMachine stateMachine;
    public GameObject spikes;
    public GameObject spikesWarn;
    public GameObject spikesMaze;
    // Start is called before the first frame update
    void Start()
    {
        //AttackTrigger();
        BossStateMachine stateMachine = GetComponent<BossStateMachine>();
        BossHeader bossHeader = GetComponent<BossHeader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackTrigger()
    {
        Debug.Log("Attack Triggered");
        BossStateMachine stateMachine = GetComponent<BossStateMachine>();
        BossHeader bossHeader = GetComponent<BossHeader>();
        StartCoroutine(Attack());
    }
    public IEnumerator Attack()
    {
        bossHeader.banimator.Play("Boss_WarpOut", 0, 0.0f);

        for (int i = 0; i < 20; i++)
        {
            yield return null;
        }
        this.transform.position = bossHeader.warpZone;
        for (int windup = 0; windup < 15; windup++)
        {
            yield return null;
        }
        this.transform.position = bossHeader.home;
        bossHeader.banimator.Play("Boss_WarpIn", 0, 0.0f);
        for (int casting = 0; casting <= 690; casting++)
        {
            if (casting+20 == 690)
            {
                bossHeader.banimator.Play("Boss_Punch", 0, 0.0f);
            }
            if ((casting + 20) % 130 == 0 && casting < 391)
            {
                bossHeader.banimator.Play("Boss_Punch", 0, 0.0f);
            }
            if (casting == 130)
            {
                Debug.Log("Warning");
                spikesWarn.SetActive(true);
            }
            if (casting == 260)
            {
                Debug.Log("Spikes");
                spikesWarn.SetActive(false);
                spikes.SetActive(true);

            }
            if (casting == 390)
            {
                Debug.Log("Maze");
                spikes.SetActive(false);   
                spikesMaze.SetActive(true);
            }
            yield return null;  
        }
        spikesMaze.SetActive(false);
        bossHeader.banimator.Play("Boss_Default");
      
        //bossHeader.banimator.Play("Boss_WarpOut", 0, 0.0f);
        stateMachine.attackFrame = 0;
        stateMachine.state = 0;

    }

}
