using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinaManager : MonoBehaviour
   // 
{
    public static SinaManager Instance;
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
