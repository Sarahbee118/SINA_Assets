using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    public GameObject textBox;
    public BossHeader bossHeader;
    public int state;
    public int attackFrame = 61;
    public int[] phase1Lottery = new int[4];
    public int[] phase2Lottery;
    public int[] currentLottery;
    public BossAttack1 attack1;
    public BossAttack2 attack2;
    public BossAttack3 attack3;
    public BossAttack4 attack4;
    public AudioClip warping;
    public AudioClip phase2Music;



    // Start is called before the first frame update
    void Start()
    {
        //phase1Lottery = [1, 2, 3, 4];
        currentLottery = phase1Lottery;
     



    }

    // Update is called once per frame
    void Update()
    {
        if (!textBox.activeSelf)
        {

       

       // state = 1;
        //Debug.Log(attackFrame);
        attackFrame++;

        switch (state)
        {
            case 0: // Idling
              //  Debug.Log("Idling");
              //  Debug.Log(phase1Lottery.Length);
                if (attackFrame == 1)
                {
                    if(bossHeader.HP < (bossHeader.maxHP / 2) && currentLottery != phase2Lottery)
                        {
                            MusicManager.Instance.musicPlayer.clip = phase2Music;
                            MusicManager.Instance.musicPlayer.Play();
                            currentLottery = phase2Lottery;
                            attackFrame = 0;
                            state = 3;
                        }
                        AudioSource.PlayClipAtPoint(warping, transform.position);
                        bossHeader.banimator.Play("Boss_WarpOut");
                }
                if (attackFrame == 20)
                {
                    this.transform.position = bossHeader.home;
                    bossHeader.banimator.Play("Boss_WarpIn");
                        AudioSource.PlayClipAtPoint(warping, transform.position);
                    }
                if (attackFrame > 120) //weighted attack lottery
                {
                    state = currentLottery[Random.Range(0, currentLottery.Length)];
                    attackFrame = 0;
                    bossHeader.banimator.Play("Boss_WarpOut");
                        AudioSource.PlayClipAtPoint(warping, transform.position);
                    }
                break;

            case 1:
                Debug.Log("Bullet Barage");
                if (attackFrame == 1)
                {
                    Debug.Log("Frame 1 Barage");
                    attack1.AttackTrigger();
                }
                break;

            case 2:
                Debug.Log("Spike Waves");
                if (attackFrame == 1)
                {
                    Debug.Log("Frame 1 Wave");
                    attack2.AttackTrigger();
                }
                break;

            case 3:
                 Debug.Log("Master Spark");
                if (attackFrame == 1)
                {
                    attack3.AttackTrigger();
                }
                break;

            case 4:
                  Debug.Log("Spike Maze");
                if (attackFrame == 1)
                {
                    Debug.Log("Frame 1 Maze");
                    attack4.AttackTrigger();
                }
                break;


        }
        }
    }
}
