using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinaManagerSaved : MonoBehaviour
   // A constant manager for Sina. Keeps track of her between framesS
{
    public static SinaManagerSaved Instance;
    public int SinaHealth;
    public int SinaMaxHealth;
    public int SinaDirection;
    public int SinaAmmo;
    public bool hasGun;
    public bool hasDash;
    public bool hasPunch2;
    public bool hasShield;
    public bool hasShrink;
    public string screenExit;
    public string currScreen;
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
      
        
        DontDestroyOnLoad(gameObject);
    }
}
