using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targets : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject zipChest;
    private bool firstCorrect;
    private bool secondCorrect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target1.activeSelf && target2.activeSelf && !target3.activeSelf)
        {
            firstCorrect = true;
        }
        if (!target1.activeSelf && target2.activeSelf && !target3.activeSelf && firstCorrect)
        {
            secondCorrect = true;
        }
        if (firstCorrect && secondCorrect && !target2.activeSelf) 
        {
            zipChest.SetActive(true);
            Destroy(gameObject);
        }
        if (!target1.activeSelf && !target2.activeSelf && !target3.activeSelf)
        {
            firstCorrect = false;
            secondCorrect = false;
            target1.SetActive(true);
            target2.SetActive(true);
            target3.SetActive(true);
        }
    }
}
