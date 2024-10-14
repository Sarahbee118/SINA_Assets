using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Sina : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float moveSpeed = 5f;
    public Rigidbody2D Rigidbody;
    private Vector2 moveDirection;
    public PlayerInputs playerControls; // Calling Input Actions see tutorial for more details
    //Tutorial: www.youtube.com/watch?v=HmXU4dZbaMw
    private InputAction move; //move actions
    private InputAction fire; // fire actions
    private InputAction interact; //interact
    private InputAction dash; // dash action
    private InputAction shrink; // shrink action
    public txt_trigger trigger; //trigger text box
    public GameObject TextBox; //the textbox itself
    public Animator animator; //Sina's animatior
    public SpriteRenderer srend; //sprite renderer, her own
    public int faceDirection; // Left = 0, Up = 1, Right = 2, Down = 3
    public GameObject bulletfab; //bullet prefab
    public int ammo; //ammo count
    public TMP_Text healthText; //text in health bar
    public TMP_Text ammoText; //text in ammo count
    private float shrunk = 0f;
    public bool moveLock = false;

    //SFX Shield Up
    //SFX Shield Down
    //SFX Shrink
    //SFX Grow
    //SFX Punch
   
    void Start()
    {
        
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

    void FixedUpdate() //fixed
    {
        Debug.Log(Rigidbody.velocity);
       
    }

    private void Awake() //On game load
    {
        playerControls = new PlayerInputs(); //Required for new input system. Idek just have it
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
            
       // Debug.Log(faceDirection);
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
        if (ammo > 0)
        {
            fire.Disable();
            moveLock = true;
            ammo--;
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


        /*switch (faceDirection)
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
        */
    }





    private void Interaction(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
        if (TextBox.activeSelf == true)
        {
            trigger.NextDialogue();
        }
        else
        {
            TextBox.SetActive(true);
            trigger.TriggerDialogue();
        }
        
    }
    private void Dash(InputAction.CallbackContext context)
    {
        if (Rigidbody.velocity.x != 0 | Rigidbody.velocity.y != 0 )
        {
            moveLock = true;
            dash.Disable();
            StartCoroutine(Dashing());
            //Debug.Log("Dash");
        }

    }

    IEnumerator Dashing()
    {
        //SFX Dash
       // Rigidbody.velocity.x = Mathf.Round(TimeTaken * 100)) / 100.0
        switch (Mathf.Round(Rigidbody.velocity.x * 100f) / 100.0f)
        {
            case 4f:
                Rigidbody.velocity = new Vector2(20f, 0f);
                break;
            case -4f:
                Rigidbody.velocity = new Vector2(-20f, 0f);
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
            default:
                switch (Mathf.Round(Rigidbody.velocity.y * 100f) / 100.0f)
                {
                    case 4f:
                        Rigidbody.velocity = new Vector2(0f, 20f);
                        break;
                    case -4f:
                        Rigidbody.velocity = new Vector2(0f,-20f);
                        break;
                    default:
                        break;
                }
                break;


        }
        for (int dashTime  = 0; dashTime <= 6; dashTime++)
        {
            yield return null;
        }
        dash.Enable();
        moveLock = false;
        
    }

    private void Shrink(InputAction.CallbackContext context)
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

    IEnumerator Shrinking()
    {
        switch (shrunk)
        {
            case 0f:
                shrunk = 1f;
                for (float shrinktime = 6; shrinktime >= 3; shrinktime--) //gives 25 frames of relaoad time 
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
                for (float shrinktime = 3; shrinktime <= 6; shrinktime++) //gives 25 frames of relaoad time 
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

    }


    private void OnDisable()
    {
        playerControls.Disable();
        move.Disable();
        fire.Disable();
        interact.Disable();
        dash.Disable();
        shrink.Disable();
    }
}
