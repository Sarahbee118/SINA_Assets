using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : MonoBehaviour
{
    public Sina sina;
    public int whichItem;
    
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
                break;
            case 4:
                Sina.hasDash = true;
                SinaManager.Instance.hasDash = true;
                Destroy(gameObject);
                break;
        }
    }
}
