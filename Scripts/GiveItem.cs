using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GiveItem : MonoBehaviour
{
    public Sina sina;
    public GameObject sinaObject;
    public int whichItem;
    public bool isChest = false;
    public Animator animator;
    public AudioClip item;
    // Start is called before the first frame update
    void Start()
    {
        sinaObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemGet()
    {
        // 0 Gun
        // 1 Punch2
        // 2 Shrink
        // 3 Shield
        // 4 Dash
        // 5 Ammo Clip
        // 6 Heart Container
        if (isChest) 
        {
            animator.Play("ChestOpen", 0, 0.0f);
        }
     StartCoroutine(giveItemwait());  
     AudioSource.PlayClipAtPoint(item, transform.position);
    }
    IEnumerator giveItemwait()
    {
        yield return null;
        GameObject textbox = GameObject.Find("txtbox");
        while (textbox.activeSelf)
        {
            yield return null;
        }

        switch (whichItem)
        {

            case 0:
                Sina.hasGun = true;
                SinaManager.Instance.SinaMaxAmmo = SinaManager.Instance.SinaMaxAmmo +10;
                Sina.maxAmmo = SinaManager.Instance.SinaMaxAmmo;
                sinaObject.GetComponent<Sina>().AmmoRefill();
                SinaManager.Instance.hasGun = true;
                Destroy(gameObject);
                break;
            case 1:
                Sina.hasPunch2 = true;
                SinaManager.Instance.hasPunch2 = true;
                Destroy(gameObject);
                break;
            case 2:
                Sina.hasShrink = true;
                SinaManager.Instance.hasShrink = true;
                Destroy(gameObject);
                break;
            case 3:
                Destroy(gameObject);
                break;
            case 4:
                Sina.hasDash = true;
                SinaManager.Instance.hasDash = true;
                Destroy(gameObject);
                break;
            case 5:
                UnityEngine.Debug.Log("Heart Drive Get");
                SinaManager.Instance.SinaMaxHealth = SinaManager.Instance.SinaMaxHealth + 2;
                Sina.maxHealth = SinaManager.Instance.SinaMaxHealth;
                UnityEngine.Debug.Log(SinaManager.Instance.SinaMaxHealth);
                sinaObject.GetComponent<Sina>().HealthRefill();
                Destroy(gameObject);
                
                break;
            case 6:
                SinaManager.Instance.SinaMaxAmmo = SinaManager.Instance.SinaMaxAmmo + 2;
                Sina.maxAmmo = SinaManager.Instance.SinaMaxAmmo;
                sinaObject.GetComponent<Sina>().AmmoRefill();
                Destroy(gameObject);
                UnityEngine.Debug.Log("AmmoClip Get");
                break;

        }
        yield return null;
    }
}
