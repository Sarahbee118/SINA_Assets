using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHeader : MonoBehaviour
{
    public float maxHP;
    public float HP;
    public int phase;
    public Vector2 home = new Vector2(0f, -8.5f);
    public Vector2 warpZone = new Vector2(0f, 6f);
    public Animator banimator;
    public SpriteRenderer brender;
    public Image healthBar; 
    public GameObject baracade;
    public BossStateMachine stateMachine;
    public BossAttack1 attack1;
    public BossAttack2 attack2;
    public BossAttack3 attack3;
    public BossAttack4 attack4;
    public BossDialogue bossDialogue;
   

    public Image fadeinout;
 
   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(HP / maxHP);
        healthBar.fillAmount = HP / maxHP;
       // Debug.Log(HP / maxHP);
        HP = maxHP;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        healthBar.fillAmount = (HP/maxHP);
        //hurt animation
        Debug.Log(HP / maxHP);
        Debug.Log(HP);
        if (HP <= 40)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy dead");


        bossDialogue.FadeTrigger();
          //  baracade.SetActive(true);
           Destroy(gameObject);
        

        //die animation
    }
}
