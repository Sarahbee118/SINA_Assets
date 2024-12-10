using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack2 : MonoBehaviour
{
    public BossHeader bossHeader;
    public BossStateMachine stateMachine;
    public GameObject spikeFab;
    public AudioClip punch;
    public AudioClip warping;
    public AudioClip spikes;

    public void Start()
    {
        //AttackTrigger();
        BossStateMachine stateMachine = GetComponent<BossStateMachine>();
        BossHeader bossHeader = GetComponent<BossHeader>();
    }

    public void AttackTrigger()
    {
        
        Debug.Log("Attack Triggered");
        StartCoroutine(Attack());
    }
    // Start is called before the first frame update

    public IEnumerator Attack()
    {
        for (int i = 0; i < 10; i++) 
        {
            yield return null;
        }
        while (Time.timeScale == 0f)
        {
            yield return null;
        }
        this.transform.position = new Vector2(-8.5f, -9.8f);
        bossHeader.banimator.Play("Boss_WarpIn");
        AudioSource.PlayClipAtPoint(warping, transform.position);

        for (int windup = 0; windup < 15; windup++)
        {
            yield return null;
        }

        for (int casting = 0; casting <= 599; casting++)
        {
            while (Time.timeScale == 0f)
            {
                yield return null;
            }
            if ((casting + 20) % 150 == 0)
            {
                bossHeader.banimator.Play("Boss_Punch", 0, 0.0f);
                AudioSource.PlayClipAtPoint(punch, transform.position);
            }
            //Debug.Log(casting);
            if (casting % 150 == 0 && casting !=0)
            {
                AudioSource.PlayClipAtPoint(spikes, transform.position);
                for (float spikeY = -3.5f; spikeY > -15f; spikeY--)
                {
                    GameObject nextSpike = Instantiate<GameObject>(spikeFab, new Vector3(-8.5f,spikeY,1f), Quaternion.identity);
                }

            }
            yield return null;
        }
        stateMachine.attackFrame = 0;
        stateMachine.state = 0;
    }
}
