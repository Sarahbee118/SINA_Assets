using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    public int state;
    public int attackFrame = 0;
    public int[] phase1Lottery = new int[4];
    public int[] phase2Lottery;
    public int[] currentLottery;
    public BossAttack1 attack1;
    public BossAttack3 attack3;


    // Start is called before the first frame update
    void Start()
    {
        //phase1Lottery = [1, 2, 3, 4];
        currentLottery = phase1Lottery;
     



    }

    // Update is called once per frame
    void Update()
    {
       // state = 1;
        //Debug.Log(attackFrame);
        attackFrame++;

        switch (state)
        {
            case 0: // Idling
              //  Debug.Log("Idling");
              //  Debug.Log(phase1Lottery.Length);
                if (attackFrame > 180) //weighted attack lottery
                {
                    state = currentLottery[Random.Range(0, currentLottery.Length)];
                    attackFrame = 0;
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
               // Debug.Log("Dashing");
                attackFrame = 0;
                state = 0;
                break;

            case 3:
                // Debug.Log("Master Spark");
                if (attackFrame == 1)
                {
                    attack3.AttackTrigger();
                }
                break;

            case 4:
              //  Debug.Log("Giant");
                attackFrame = 0;
                state = 0;
                break;


        }
    }
}
