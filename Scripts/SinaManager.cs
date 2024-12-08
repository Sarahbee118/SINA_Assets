using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinaManager : MonoBehaviour
   // A constant manager for Sina. Keeps track of her between framesS
{
    public static SinaManager Instance;
    public int SinaHealth;
    public int SinaMaxHealth;
    public int SinaDirection;
    public int SinaAmmo;
    public int SinaMaxAmmo;
    public bool hasGun;
    public bool hasDash;
    public bool hasPunch2;
    public bool hasShield;
    public bool hasShrink;
    public bool heart1;
    public bool heart2;
    public bool heart3;
    public bool ammo1;
    public bool ammo2;
    public bool ammo3;
    public bool ammo4;
    public bool ammo5;
    public string screenExit;
    public string currScreen;
    public bool introComplete;
    // Start is called before the first frame update
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
      
       // SavedInstance.currScreen = "C2";
        DontDestroyOnLoad(gameObject);
    }
}
