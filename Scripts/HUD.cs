using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image gun;
    public Image shield;
    public Image dash;
    public Image punch;
    public Image punch2;
    public Image shrink;
    // Start is called before the first frame update
    void Start()
    {
        if (SinaManager.Instance.hasGun)
        {
            gun.enabled = true;

        }
        else
        {
            gun.enabled = false;
        }

        if (SinaManager.Instance.hasShield)
        {
            shield.enabled = true;
        }
        else {
            shield.enabled = false;
            }

        if (SinaManager.Instance.hasShrink)
        {
            shrink.enabled = true;
        }
        else
        {
            shrink.enabled = false;
        }

        if (SinaManager.Instance.hasDash)
        {
            dash.enabled = true;
        }
        else
        {
            dash.enabled = false;
        }

        if (SinaManager.Instance.hasPunch2)
        {
            punch2.enabled = true;
            punch.enabled = false;

        }
        else
        {
            punch2.enabled = false;
            punch.enabled = true;
        }

            
                
    }


    public void Refresh()
    {
        if (SinaManager.Instance.hasGun)
        {
            gun.enabled = true;

        }
        else
        {
            gun.enabled = false;
        }

        if (SinaManager.Instance.hasShield)
        {
            shield.enabled = true;
        }
        else
        {
            shield.enabled = false;
        }

        if (SinaManager.Instance.hasShrink)
        {
            shrink.enabled = true;
        }
        else
        {
            shrink.enabled = false;
        }

        if (SinaManager.Instance.hasDash)
        {
            dash.enabled = true;
        }
        else
        {
            dash.enabled = false;
        }

        if (SinaManager.Instance.hasPunch2)
        {
            punch2.enabled = true;
            punch.enabled = false;

        }
        else
        {
            punch2.enabled = false;
            punch.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
