using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GiveItem : MonoBehaviour
{
    public Sina sina;
    public int whichItem;
    public bool isChest = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
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
                SinaManager.Instance.hasGun = true;
                Destroy(gameObject);
                break;
            case 1:
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
                Destroy(gameObject);
                UnityEngine.Debug.Log("Heart Drive Get");
                break;
            case 6:
                Destroy(gameObject);
                UnityEngine.Debug.Log("AmmoClip Get");
                break;

        }
        yield return null;
    }
}
