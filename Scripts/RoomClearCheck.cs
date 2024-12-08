using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomClearCheck : MonoBehaviour
{
    public string room;
    // Start is called before the first frame update
    void Start()
    {
        switch (room)
        {
            case "A1":
                if (SinaManager.Instance.heart1)
                {
                   Destroy(gameObject);
                }
                break;
            case "A2":
                if (SinaManager.Instance.ammo1)
                {
                    Destroy(gameObject);
                }
                break;
            case "A3":
                if (SinaManager.Instance.hasShrink)
                {
                    Destroy(gameObject);
                }
                break;
            case "B1":
                if (SinaManager.Instance.ammo2)
                {
                    Destroy(gameObject);
                }
                break;
            case "B2":
                if (SinaManager.Instance.ammo3)
                {
                    Destroy(gameObject);
                }
                break;
            case "B3":
                break;
            case "C1":
                break;
            case "C2":
                if (SinaManager.Instance.hasGun)
                {
                    Destroy(gameObject);
                }
                break;
            case "SinaRoom":
                if (SinaManager.Instance.heart2)
                {
                    Destroy(gameObject);
                }
                break;
            case "D1":
                if (SinaManager.Instance.hasDash)
                {
                    Destroy(gameObject);
                }
                break;
            case "D2":
                if (SinaManager.Instance.heart3)
                {
                    Destroy(gameObject);
                }
                break;
            case "D3":
                if (SinaManager.Instance.ammo4)
                {
                    Destroy(gameObject);
                }
                break;
            case "E1":
                if (SinaManager.Instance.hasPunch2)
                {
                    Destroy(gameObject);
                }
                break;
            case "E2":
                if (SinaManager.Instance.ammo5)
                {
                    Destroy(gameObject);
                }
                break;
            case "E3":
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
