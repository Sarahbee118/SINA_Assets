using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class residue : MonoBehaviour
{
    public Image healthBar;
    public Image residueBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.fillAmount < residueBar.fillAmount)
        {
            residueBar.fillAmount -= .001f;
        }
        if (residueBar.fillAmount < healthBar.fillAmount)
        {
            residueBar.fillAmount = healthBar.fillAmount;
        }
    }
}
