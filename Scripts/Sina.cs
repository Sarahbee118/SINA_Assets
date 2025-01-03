using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Transform = UnityEngine.Transform;
using TMPro;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Sina : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float moveSpeed = 5f;
    public Rigidbody2D Rigidbody;
    private Vector2 moveDirection;
    public PlayerInputs playerControls; // Calling Input Actions see tutorial for more details
    //Tutorial: www.youtube.com/watch?v=HmXU4dZbaMw
    //input action
    private InputAction move; //move actions
    private InputAction fire; // fire actions
    private InputAction interact; //interact
    private InputAction dash; // dash action
    private InputAction shrink; // shrink action
    private InputAction shield;
    //text
    private bool iframes = false;
    public txt_trigger trigger; //trigger text box
    public GameObject TextBox; //the textbox itself
    public Transform interactPoint; //npc sphere
    public float interactRange = 0.5f; //range to interact
    //animation
    public Animator animator; //Sina's animatior
    public SpriteRenderer srend; //sprite renderer, her own
    private int faceDirection; // Left = 0, Up = 1, Right = 2, Down = 3
    //gun
    public GameObject bulletfab; //bullet prefab
    public int ammo; //ammo count
    public int health;
    public static int maxHealth;
    public static int maxAmmo;
    public TMP_Text healthText; //text in health bar
    public string hearts = "<3<3<3<3<3<3<3";
    public TMP_Text ammoText; //text in ammo count
    //shrink
    private float shrunk = 0f;
    public bool moveLock = false;
    //punch
    private InputAction punch; // punch action
    public Transform attackPoint;
    public float attackRange = 0.7f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public GameObject punchfab;
    public GameObject punch2fab;
    public GameObject intFab;
    public bool punchPower = false;
    //
    public AudioClip shoot; //shoot sfx
    public AudioClip reload; //reload sfx
    public AudioClip punched; //punch sfx
    public AudioClip zoom; // dash sfx
    public AudioClip grow; // grow sfx
    public AudioClip small; // shrink sfx
    public AudioClip ow; //hurt sfx
    public AudioClip protect; //shield down sfx
    public AudioClip shielddown; //shield up sfx
    public AudioClip die; //game over sfx
    public static bool hasGun;
    public static bool hasDash;
    public static bool hasPunch2;
    public static bool hasShield;
    public static bool hasShrink;

    public static string screenExit;
    public GameObject feetCollision;
    public GameObject hurtCollision;
    private float timer;
    public GameObject shieldOb;
    private Coroutine shieldRoutine = null;
    public Tilemap tilemap;

    //SFX Shield Up
    //SFX Shield Down
    //SFX Shrink
    //SFX Grow
    //SFX Punch

    void Start()
    {
        GameObject tiles = GameObject.Find("Background");
        tiles = tiles.transform.Find("Grid").gameObject;
        tilemap = tiles.transform.Find("Gaps").gameObject.GetComponent<Tilemap>();
        switch (faceDirection)
        {
            case 0:
                srend.flipX = true;
                animator.Play("Sina_DefaultR", 0, 0.0f);
                break;
            case 1:
                animator.Play("Sina_DefaultB", 0, 0.0f);
                break;
            case 2:
                srend.flipX = false;
                animator.Play("Sina_DefaultR", 0, 0.0f);
                break;
            case 3:
                animator.Play("Sina_Default", 0, 0.0f);
                break;
            default:
                animator.Play("Sina_DefaultF", 0, 0.0f);
                break;
        }
        StartCoroutine(BootUp());
    }

    // Update is called once per frame
    void Update() //calls based on FPS
    {
        ProcessInputs();
        if (TextBox.activeSelf == false)
        {
            if (moveLock == false)
            {
                Move(); //So movement is fixed
            }    
            
        }
        else
        {
            Rigidbody.velocity = new Vector2(0f, 0f); //stop movment when textbox is open
            animator.SetInteger("XSpeed",0); //stop walking anim 
            animator.SetInteger("YSpeed", 0); //on both axes
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.otherCollider.name);
        if (collision.otherCollider.name == "MainCollision" && dash.enabled == false)
        {
            Rigidbody.velocity = new Vector2(0f, 0f);
            StopCoroutine(Dashing());
            feetCollision.SetActive(true);
            dash.Enable();
            moveLock = false;
            Rigidbody.velocity = new Vector2(0f, 0f);
        }
        if (collision.otherCollider.name == "Hurtbox")
        {
            /*if (collision.gameObject.GetComponent<enemy>().damage == false)
            {
                Debug.Log("do nothing");
            }*/
            //else if (collision.gameObject.GetComponent<enemy>().damage == true)
            //if (collision.gameObject.GetComponent<enemy>().damage == true || collision.gameObject.GetComponent<enemy>() == null)
           // {
                StartCoroutine(TakeDamage());
            //}
        }
       
    }

    public void HealthRefill()
    {
        SinaManager.Instance.SinaHealth = maxHealth;
        health = maxHealth;
        healthText.text = hearts.Substring(0, health);

    }

    public void AmmoRefill()
    {
        SinaManager.Instance.SinaAmmo = maxAmmo;
        ammo = maxAmmo;
        ammoText.text = "Ammo x" + ammo;
    }
    IEnumerator TakeDamage()
    {
        if (!iframes)
        {
            iframes = true;
            health -= 1;
            SinaManager.Instance.SinaHealth -= 1;
            healthText.text = hearts.Substring(0, health);

            if (health <= 0)
            {
                StartCoroutine(GameOver());
                StopCoroutine(TakeDamage());
            }
            else
            {
                Debug.Log("I");
                for (int iframe = 0; iframe < 90; iframe++)
                {
                    if (iframe % 10 == 0)
                    {
                        srend.enabled = !srend.enabled;
                    }
                    if (iframe == 15 && health != 0)
                    {
                        moveLock = false;
                    }
                    yield return null;
                }
                srend.enabled = true;
                iframes = false;
            }
        }





    }

    IEnumerator GameOver()
    {
        moveLock = true;
        shrink.Disable();
        fire.Disable();
        dash.Disable();
        punch.Disable();
        interact.Disable();
        animator.Play("Sina_Die", 0, 0.0f);
        for (int i = 0; i < 60; i++)
        {
            Rigidbody.velocity = new Vector2(0f, 0f);
            yield return null;
        }
        srend.enabled = false;
        for (int i = 0; i < 20; i++)
        {
            Rigidbody.velocity = new Vector2(0f, 0f);
            yield return null;
        }
        if (SinaManager.Instance.introComplete)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            BossDialogue bd = GameObject.Find("BossDialogue").GetComponent<BossDialogue>();
            StartCoroutine(bd.FadeOut());
            SinaManager.Instance.SinaDirection = 3;
            SinaManager.Instance.SinaHealth = SinaManager.Instance.SinaMaxHealth;
            SceneManager.LoadScene("C1");
        }




    }



    void FixedUpdate() //fixed
    {
        //Debug.Log(Rigidbody.velocity);
       
    }

    private void Awake() //On game load
    {
        playerControls = new PlayerInputs(); //Required for new input system. Idek just have it
        if (SinaManager.Instance != null)
        {
            ammo = SinaManager.Instance.SinaAmmo;
            faceDirection = SinaManager.Instance.SinaDirection;
            health = SinaManager.Instance.SinaHealth;
            hasGun = SinaManager.Instance.hasGun;
            hasDash = SinaManager.Instance.hasDash;
            hasPunch2 = SinaManager.Instance.hasPunch2;
            hasShield = SinaManager.Instance.hasShield;
            hasShrink = SinaManager.Instance.hasShrink;
            ammo = SinaManager.Instance.SinaAmmo;
            health = SinaManager.Instance.SinaHealth;
            ammoText.text = "Ammo x" + ammo;
            maxAmmo = SinaManager.Instance.SinaMaxAmmo;
            maxHealth = SinaManager.Instance.SinaMaxHealth;
        }
        else
        {
            ammo = 10;
            faceDirection = 1;
            ammoText.text = "Ammo x" + ammo;
            health = 12;
            hasGun = true;
            hasDash = true;
            hasPunch2 = true;
            hasShield = true;
            screenExit = "top";

        }
        
    }
    void ProcessInputs()
    {

        moveDirection = move.ReadValue<Vector2>(); //Reads the vector2 of the movement inputs
        moveDirection.x = Mathf.RoundToInt(moveDirection.x);
        moveDirection.y = Mathf.RoundToInt(moveDirection.y);
                                                   // Debug.Log(moveDirection.x.ToString());
        moveDirection = moveDirection.normalized;
       if (moveDirection.y != 0f) //if you're moving on the vert axis
        {
            switch (moveDirection.y)
            {
                case 1f: //facing up
                    faceDirection = 1;
                    break;  
                case -1f: //facing down
                    faceDirection = 3;
                    break;
                default:
                    break;
            }
        } //What direction Sina is facing
       else
        {
            switch (moveDirection.x) //if moving on hor axis and not vert
            {
                case 1f: //facing right 
                    faceDirection = 2; 
                    break;
                case -1f:
                    faceDirection = 0;  //facing left
                    break;
                default:
                    break;
            }
        }
        SinaManager.Instance.SinaDirection = faceDirection;
       // Debug.Log(faceDirection);
    }

    IEnumerator BootUp()
    {
        for (int i = 0; i < 1; i++)
        {
            yield return  new WaitForEndOfFrame();
        }
        if (SinaManager.Instance != null)
        {
            ammo = SinaManager.Instance.SinaAmmo;
            faceDirection = SinaManager.Instance.SinaDirection;
            health = SinaManager.Instance.SinaHealth;
            hasGun = SinaManager.Instance.hasGun;
            hasDash = SinaManager.Instance.hasDash;
            hasPunch2 = SinaManager.Instance.hasPunch2;
            hasShield = SinaManager.Instance.hasShield;
            hasShrink = SinaManager.Instance.hasShrink;
            ammo = SinaManager.Instance.SinaAmmo;
            health = SinaManager.Instance.SinaHealth;
            ammoText.text = "Ammo x" + ammo;
            healthText.text = hearts.Substring(0, health);
            maxAmmo = SinaManager.Instance.SinaMaxAmmo;
            maxHealth = SinaManager.Instance.SinaMaxHealth;
        }
        else
        {
            ammo = 10;
            faceDirection = 1;
            ammoText.text = "Ammo x" + ammo;
            health = 12;
            hasGun = true;
            hasDash = true;
            hasPunch2 = true;
            hasShield = true;
            screenExit = "top";

        }
    }

    private void Move()  ////Tutorial used to help write this code www.youtube.com/watch?v=u8tot-X_RBI
    {
     

        Rigidbody.velocity = new Vector2(moveDirection.x *(moveSpeed-(shrunk*.5f)), moveDirection.y *(moveSpeed - (shrunk * .5f))); //Math on moving player char
        //Debug.Log(Rigidbody.velocity.ToString());

        switch(Mathf.RoundToInt(moveDirection.x)) //whether to flip sprite
        {
            //SFX Footsteps
            case 0:
                //srend.flipX = false;
                break;
            case 1:
                srend.flipX = false; //moving right dont flip sprite
                break;
            case -1:
                srend.flipX = true; //moving left flip
                break;
            default:
                //srend.flipX = false;
                break;
        }
        animator.SetInteger("XDirection", Mathf.RoundToInt(moveDirection.x)); //changes sprite direction
        animator.SetInteger("YDirection", Mathf.RoundToInt(moveDirection.y)); //based on movement
        animator.SetInteger("YSpeed",Mathf.RoundToInt(Rigidbody.velocity.y)); //if moving y
        animator.SetInteger("XSpeed", Mathf.Abs(Mathf.RoundToInt(Rigidbody.velocity.x))); //if moving x
        //Debug.Log(Mathf.Abs(Mathf.RoundToInt(Rigidbody.velocity.x)));

    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log(hasGun);
        if (hasGun)
        {
            if (ammo > 0)
            {
                fire.Disable();
                moveLock = true;
                AudioSource.PlayClipAtPoint(shoot, transform.position);
                ammo--;
                SinaManager.Instance.SinaAmmo = ammo;
                ammoText.text = "Ammo x" + ammo;
                Debug.Log(ammo);
                // StopCoroutine(Firing());
                //SFX Gun Shot
                animator.SetBool("Firing", true);
                GameObject bullet = Instantiate<GameObject>(bulletfab, transform.position, Quaternion.identity);

                switch (faceDirection) //shoots bulet in faced direction
                {
                    case 0:
                        animator.Play("Sina_FireR", 0, 0.0f); //firing animation
                        bullet.transform.position = bullet.transform.position + new Vector3(-.6f, 0, 0); //start bullet in direction
                        bullet.transform.Rotate(0.0f, 0.0f, 90.0f, 0f); //rotates it acordingly
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0); //fires it
                        break; //break
                    case 1:
                        animator.Play("Sina_FireB", 0, 0.0f);
                        bullet.transform.position = bullet.transform.position + new Vector3(0, .3f, 0);
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
                        break;
                    case 2:
                        animator.Play("Sina_FireR", 0, 0.0f);
                        bullet.transform.position = bullet.transform.position + new Vector3(.6f, 0, 0);
                        bullet.transform.Rotate(0.0f, 0.0f, 270.0f, 0f);
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
                        break;
                    case 3:
                        animator.Play("Sina_FireF", 0, 0.0f);
                        bullet.transform.position = bullet.transform.position + new Vector3(0, -.3f, 0);
                        bullet.transform.Rotate(00.0f, 0.0f, 90.0f, 0f);
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -15);
                        break;
                        //
                }
                //animator.Play("Sina_GunFire");
                //Debug.Log("Bang!"); //Bang Bang Banki Banki!

                StartCoroutine(Firing());
            }
            else
            {
                Debug.Log("Reload");
                ammo = 0;
                StartCoroutine(Reloading());
            }
            /*if (ammo == 0)
            {
                fire.Disable();                
                if (ammo != maxAmmo)
                {
                    timer += Time.deltaTime;

                    while (timer !=7)
                    {
                        ammo += 1;
                        Debug.Log(ammo);
                    }

                    timer = 0;
                }

            }*/
        }
        
    }

    IEnumerator Reloading()
    {
        int tempMax = maxAmmo;
        fire.Disable();
        Debug.Log(maxAmmo);
        for (int bullets = 0;  bullets < tempMax; bullets++)
        {
            Debug.Log("ReloadCount");
            ammo += 1;
            ammoText.text = "Ammo x" + ammo;
            float reloadtime = 5f / (float)maxAmmo;
            SinaManager.Instance.SinaAmmo = ammo;
            yield return new WaitForSeconds(reloadtime);

        }
        fire.Enable();
        
    }


    IEnumerator Firing() //while firing
    {
        for (int firingtime = 0; firingtime <= 25; firingtime++) //gives 25 frames of reload time 
        {
            Rigidbody.velocity = new Vector2(0f, 0f); //stop movment
            animator.SetInteger("XSpeed", 0); 
            animator.SetInteger("YSpeed", 0);
            yield return null; //next frame
        }
        fire.Enable(); //enable firing again
        //SFX Reload Clip
        moveLock = false;
        animator.SetBool("Firing", false);
        AudioSource.PlayClipAtPoint(reload, transform.position);


        switch (faceDirection)
        {
            case 0:
                animator.Play("Sina_DefaultR");
                break;
            case 1:
                animator.Play("Sina_DefaultB");
                break;
            case 2:
                animator.Play("Sina_DefaultR");
                break;
            case 3:
                animator.Play("Sina_DefaultF");
                break;


        }
        
    }

    private void Interaction(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
        if (TextBox.activeSelf == true)
        {
            trigger.NextDialogue();
            if (TextBox.activeSelf == false)
            {
                moveLock = false;

            }

        }
        else
        {
            //moveLock = true;
            //TextBox.SetActive(true);
            //trigger.TriggerDialogue();
            GameObject heyo = Instantiate<GameObject>(intFab, transform.position, Quaternion.identity);
            switch (faceDirection) //punch appears in faced direction
            {
                case 0:
                    heyo.transform.position = heyo.transform.position + new Vector3(-.2f, 0, 0); //start bullet in direction
                   // heyo.transform.Rotate(0.0f, 0.0f, 90.0f, 0f); //rotates it acordingly
                    break; //break
                case 1:
                    heyo.transform.position = heyo.transform.position + new Vector3(0, .2f, 0);
                    break;
                case 2:
                    heyo.transform.position = heyo.transform.position + new Vector3(.2f, 0, 0);
                    //heyo.transform.Rotate(0.0f, 0.0f, 270.0f, 0f);
                    Debug.Log("DownInt");                  
                    break;
                case 3:

                    heyo.transform.position = heyo.transform.position + new Vector3(0, -.2f, 0);
                   // heyo.transform.Rotate(0.0f, 0.0f, 180f, 0f); /////not facing the right direction
                    break;
                    //
            }

        }
        
    }
    private void Dash(InputAction.CallbackContext context)
    {
        if (hasDash)
        {
            Debug.Log("Dash");
            Debug.Log(Rigidbody.velocity.x);
            if (Rigidbody.velocity.x != 0 | Rigidbody.velocity.y != 0)
            {
                moveLock = true;
                dash.Disable();
                StartCoroutine(Dashing());
                //Debug.Log("Dash");
            }
        }


    }

    IEnumerator Dashing()
    {
        Vector2 startPos = this.transform.position;
        feetCollision.SetActive(false);
        hurtCollision.SetActive(false);

        //SFX Dash
        // Rigidbody.velocity.x = Mathf.Round(TimeTaken * 100)) / 100.0
        switch (Mathf.Round(Rigidbody.velocity.x * 100f) / 100.0f)
        {
            case 4f:
                Rigidbody.velocity = new Vector2(25f, 0f);
                break;
            case 3.5f:
                Rigidbody.velocity = new Vector2(25f, 0f);
                break;
            case -3.5f:
                Rigidbody.velocity = new Vector2(-25f, 0f);
                break;
            case -4f:
                Rigidbody.velocity = new Vector2(-25f, 0f);
                break;
            case 2.83f:
                Debug.Log("AAAAAAA");
                switch (Mathf.Round(Rigidbody.velocity.y * 100f) / 100.0f)
                {
                    case 2.83f:
                        Rigidbody.velocity = new Vector2(14.14f, 14.14f);
                        Debug.Log("A");
                        break;
                    case -2.83f:
                        Rigidbody.velocity = new Vector2(14.14f, -14.14f);
                        Debug.Log("A");
                        break;

                }
                break;
            case 2.47f:
                Debug.Log("AAAAAAA");
                switch (Mathf.Round(Rigidbody.velocity.y * 100f) / 100.0f)
                {
                    case 2.47f:
                        Rigidbody.velocity = new Vector2(14.14f, 14.14f);
                        Debug.Log("A");
                        break;
                    case -2.47f:
                        Rigidbody.velocity = new Vector2(14.14f, -14.14f);
                        Debug.Log("A");
                        break;

                }
                break;
            case -2.83f:
                switch (Mathf.Round(Rigidbody.velocity.y * 100f) / 100.0f)
                {
                    case 2.83f:
                        Rigidbody.velocity = new Vector2(-14.14f, 14.14f);
                        break;
                    case -2.83f:
                        Rigidbody.velocity = new Vector2(-14.14f, -14.14f);
                        break;

                }
                break;
            case -2.47f:
                switch (Mathf.Round(Rigidbody.velocity.y * 100f) / 100.0f)
                {
                    case 2.47f:
                        Rigidbody.velocity = new Vector2(-14.14f, 14.14f);
                        break;
                    case -2.47f:
                        Rigidbody.velocity = new Vector2(-14.14f, -14.14f);
                        break;

                }
                break;
            default:
                switch (Mathf.Round(Rigidbody.velocity.y * 100f) / 100.0f)
                {
                    case 4f:
                        Rigidbody.velocity = new Vector2(0f, 20f);
                        break;
                    case -4f:
                        Rigidbody.velocity = new Vector2(0f, -20f);
                        break;
                    case 3.5f:
                        Rigidbody.velocity = new Vector2(0f, 20f);
                        break;
                    case -3.5f:
                        Rigidbody.velocity = new Vector2(0f, -20f);
                        break;
                    default:
                        break;
                }
                break;


        }
        for (int dashTime = 0; dashTime <= 6; dashTime++)
        {
            /* if (Mathf.Abs(Rigidbody.velocity.x) != 20f || Mathf.Abs(Rigidbody.velocity.x) != 14f | Mathf.Abs(Rigidbody.velocity.y) != 20f || Mathf.Abs(Rigidbody.velocity.y) != 14f)
             {
                 Rigidbody.velocity = new Vector2(0f, 0f);
                 dashTime = 7;
             } */
            yield return null;

        }
        feetCollision.SetActive(true);
        hurtCollision.SetActive(true);
        Vector3 postdashpos = transform.position;

        Vector3Int world = tilemap.WorldToCell(postdashpos);
        Debug.Log(world);

        if (tilemap.HasTile(world))
        {
            Debug.Log("gap here");
            transform.position = startPos;
            StartCoroutine(TakeDamage());
        }
        dash.Enable();
        moveLock = false;

    }


    private void Shrink(InputAction.CallbackContext context)
    {
        if (hasShrink)
        {
             //SFX Dash
        shrink.Disable();
        moveLock = true;
        Debug.Log("Shrink");
        StartCoroutine(Shrinking());
        // animator.SetBool("Shrinking", true);
        //  faceDirection = 3;
        // animator.Play("Sina_DeafaultF", 0, 0.0f);
        // transform.localScale = new Vector2(3f, 3f);
        }
        else
        {
            Debug.Log(SinaManager.Instance.hasShrink);
            Debug.Log("Not Shrink");
        }
       
    }

    IEnumerator Shrinking()
    {
        switch (shrunk)
        {
            case 0f:
                shrunk = 1f;
                AudioSource.PlayClipAtPoint(small, transform.position);
                for (float shrinktime = 1f; shrinktime >= .5f; shrinktime = shrinktime -.1f) //gives 25 frames of relaoad time 
                {
                    Rigidbody.velocity = new Vector2(0f, 0f); //stop movment
                    animator.SetInteger("XSpeed", 0);
                    animator.SetInteger("YSpeed", 0);
                    transform.localScale = new Vector2(shrinktime, shrinktime);
                    Vector3 shrinkPos = new Vector3(0f, -.08f, 0f);
                    transform.localPosition += shrinkPos;
                    yield return null; //next frame
                }
                break;

            case 1f:
                shrunk = 0f;
                AudioSource.PlayClipAtPoint(grow, transform.position);
                for (float shrinktime = .5f; shrinktime <= 1f; shrinktime=shrinktime+.1f) //gives 25 frames of relaoad time 
                {
                    Rigidbody.velocity = new Vector2(0f, 0f); //stop movment
                    animator.SetInteger("XSpeed", 0);
                    animator.SetInteger("YSpeed", 0);
                    transform.localScale = new Vector2(shrinktime, shrinktime);
                    Vector3 shrinkPos = new Vector3(0f, .08f, 0f);
                    transform.localPosition += shrinkPos;
                    yield return null; //next frame
                }
                break;
        }
       
        shrink.Enable();
        moveLock = false;
    }
    private void Punch(InputAction.CallbackContext context)
    {
        //SFX Punch
        //Debug.Log("Punch");

        punch.Disable();
        //moveLock = true;
        StartCoroutine(Punching());
        animator.SetBool("Punching", true);
        AudioSource.PlayClipAtPoint(punched, transform.position);


        //Collider2D[] personalSpace = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        /*GameObject kapow = Instantiate<GameObject>(punchfab, transform.position, Quaternion.identity);
        switch (faceDirection) //punch appears in faced direction
        {
            case 0:
                animator.Play("Sina_DefaultR", 0, 0.0f); //firing animation
                Debug.Log("punch r");
                kapow.transform.position = kapow.transform.position + new Vector3(-.8f, 0, 0); //start bullet in direction
                kapow.transform.Rotate(0.0f, 0.0f, 90.0f, 0f); //rotates it acordingly
                break; //break
            case 1:
                animator.Play("Sina_DefaultB", 0, 0.0f);
                Debug.Log("punch b");
                kapow.transform.position = kapow.transform.position + new Vector3(0, 1f, 0);
                break;
            case 2:
                animator.Play("Sina_DefaultR", 0, 0.0f);
                Debug.Log("punch l");
                kapow.transform.position = kapow.transform.position + new Vector3(.8f, 0, 0);
                kapow.transform.Rotate(0.0f, 0.0f, 270.0f, 0f);
                break;
            case 3:
                animator.Play("Sina_DefaultF", 0, 0.0f);
                Debug.Log("punch f");
                kapow.transform.position = kapow.transform.position + new Vector3(0, -1f, 0);
                kapow.transform.Rotate(0.0f, 0.0f, 180f, 0f); /////not facing the right direction
                break;
                //
        } */

        /*
        //foreach(Collider2D enemy in hitEnemies)
        // foreach (Collider2D thing in personalSpace)
        {
            if (thing.GetComponent<enemy>() != null)
            {

                //if (punchPower = false)
                //{

                thing.GetComponent<enemy>().TakeDamage(attackDamage);



                //moveLock = false;
            }
            else if (thing.GetComponent<npc>() != null)
            {
                thing.GetComponent<npc>().Interact();
                Debug.Log("im speaking");
            }
            /*else
            {
                GameObject kapow = Instantiate<GameObject>(punchfab, transform.position, Quaternion.identity);
                thing.GetComponent<enemy>().TakeDamage(attackDamage+15);
                switch (faceDirection) //punch appears in faced direction
                {
                    case 0:
                        animator.Play("Sina_DefaultR", 0, 0.0f); //firing animation
                        Debug.Log("punch r");
                        kapow.transform.position = kapow.transform.position + new Vector3(-.8f, 0, 0); //start bullet in direction
                        kapow.transform.Rotate(0.0f, 0.0f, 90.0f, 0f); //rotates it acordingly
                        break; //break
                    case 1: 
                        animator.Play("Sina_DefaultB", 0, 0.0f);
                        Debug.Log("punch b");
                        kapow.transform.position = kapow.transform.position + new Vector3(0, 1f, 0);
                        break;
                    case 2:
                        animator.Play("Sina_DefaultR", 0, 0.0f);
                        Debug.Log("punch r 2");
                        kapow.transform.position = kapow.transform.position + new Vector3(.8f, 0, 0);
                        kapow.transform.Rotate(0.0f, 0.0f, 270.0f, 0f);
                        break;
                    case 3:
                        animator.Play("Sina_DefaultF", 0, 0.0f);
                        Debug.Log("punch f");
                        kapow.transform.position = kapow.transform.position + new Vector3(0, -1f, 0);
                        kapow.transform.Rotate(0.0f, 0.0f, 0.0f, 0f); /////not facing the right direction
                        break;
                        //
                }

                //moveLock = false;
            }
        
         
         
         }*/





        



        

    }
    

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator Punching() //while punching
    {
        switch (faceDirection) //punch appears in faced direction
        {
            case 0:
                animator.Play("Sina_PunchR", 0, 0.0f); //firing animation
                Debug.Log("punch r");
                break; //break
            case 1:
                animator.Play("Sina_PunchB", 0, 0.0f);
                Debug.Log("punch b");
                break;
            case 2:
                animator.Play("Sina_PunchR", 0, 0.0f);
                Debug.Log("punch l");
                break;
            case 3:
                animator.Play("Sina_PunchF", 0, 0.0f);
                Debug.Log("punch f");
                break;
                //
        }
        for (int punchingtime = 0; punchingtime <= 12; punchingtime++) //gives 25 frames of relaoad time 
        {
            Rigidbody.velocity = new Vector2(0f, 0f); //stop movment
            animator.SetInteger("XSpeed", 0);
            animator.SetInteger("YSpeed", 0);
            yield return null; //next frame
        }
        GameObject kapow;
        if (hasPunch2)
        {
            
            kapow = Instantiate<GameObject>(punch2fab, transform.position, Quaternion.identity);
        }
        else
        {
            kapow = Instantiate<GameObject>(punchfab, transform.position, Quaternion.identity);
        }
        
        
           
        
        
        switch (faceDirection) //punch appears in faced direction
        {
            case 0:
                kapow.transform.position = kapow.transform.position + new Vector3(-.8f, 0, 0); //start bullet in direction
                kapow.transform.Rotate(0.0f, 0.0f, 90.0f, 0f); //rotates it acordingly
                break; //break
            case 1:
                kapow.transform.position = kapow.transform.position + new Vector3(0, 1f, 0);
                break;
            case 2:
                kapow.transform.position = kapow.transform.position + new Vector3(.8f, 0, 0);
                kapow.transform.Rotate(0.0f, 0.0f, 270.0f, 0f);
                break;
            case 3:
               
                kapow.transform.position = kapow.transform.position + new Vector3(0, -1f, 0);
                kapow.transform.Rotate(0.0f, 0.0f, 180f, 0f); /////not facing the right direction
                break;
                //
        }
        for (int punchingtime = 0; punchingtime <= 15; punchingtime++) //gives 25 frames of relaoad time 
        {
            Rigidbody.velocity = new Vector2(0f, 0f); //stop movment
            animator.SetInteger("XSpeed", 0);
            animator.SetInteger("YSpeed", 0);
            yield return null; //next frame
        }
        animator.SetBool("Punching", false);
        punch.Enable(); //enable punching again
        //moveLock = false;

    }

    private void Shield(InputAction.CallbackContext context)
    {
        if (hasShield)
        {
            Debug.Log("Shield");

            if (ammo > 0)
            {
                if (!shieldOb.activeSelf)
                {
                    punch.Disable();
                    fire.Disable();
                    shieldOb.SetActive(true);
                    shieldRoutine = StartCoroutine(Shielding());
                }
                else
                {
                    punch.Enable();
                    fire.Enable();
                    StopCoroutine(shieldRoutine);
                    shieldOb.SetActive(false);
                    hurtCollision.gameObject.SetActive(true);
                }
            }
        }

    }

    IEnumerator Shielding() //while punching
    {
        hurtCollision.gameObject.SetActive(false);
        while (ammo > 0) 
        {
            Debug.Log("Decriment");
            ammo--;
            ammoText.text = "Ammo x" + ammo;
            yield return new WaitForSeconds(.25f);
        }
        hurtCollision.gameObject.SetActive(true);
        shieldOb.SetActive(false);
        fire.Enable();
        punch.Enable();
    }

    private void OnEnable() //Required for new input system
    {
        
        move = playerControls.Player.Move; //Assigns Move in Movement Action to move
        move.Enable();
        fire = playerControls.Player.Fire; //same but for fire
        fire.Enable();
        fire.performed += Fire; //when pressed, do 
        interact = playerControls.Player.Interact;  
        interact.Enable();
        interact.performed += Interaction;
        dash = playerControls.Player.Dash;
        dash.Enable();
        dash.performed += Dash;
        shrink = playerControls.Player.Shrink;
        shrink.Enable();
        shrink.performed += Shrink;
        punch = playerControls.Player.Punch;
        punch.Enable();
        punch.performed += Punch;
        shield = playerControls.Player.Shield;
        shield.Enable();
        shield.performed += Shield;

    }


    private void OnDisable()
    {
        playerControls.Disable();
        move.Disable();
        fire.Disable();
        interact.Disable();
        dash.Disable();
        shrink.Disable();
        punch.Disable();
        shield.Disable();
    }

    
}
