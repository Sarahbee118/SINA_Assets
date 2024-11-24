using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    public Transform handPosition; // Reference to the hand position
    public GameObject shield; // Reference to the shield GameObject
    public GameObject pickupMessageUI; // Reference to a UI message (optional)

    private bool shieldPickedUp = false;

    void Start()
    {
        // Make sure the shield is not visible initially
        if (shield != null)
        {
            shield.SetActive(false);
        }
    }

    void Update()
    {
        // Press X to pick up or drop the shield
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (shieldPickedUp)
            {
                DropShield();
            }
            else
            {
                PickUpShield();
            }
        }
    }

    void PickUpShield()
    {
        if (shield != null)
        {
            // Make the shield appear and attach it to the hand
            shield.SetActive(true);
            shield.transform.SetParent(handPosition); // Attach to hand
            shield.transform.localPosition = Vector3.zero; // Align position
            shield.GetComponent<Rigidbody2D>().isKinematic = true; // Disable physics
            shieldPickedUp = true;

            // Announce pickup
            if (pickupMessageUI != null)
            {
                pickupMessageUI.SetActive(true);
            }
        }
    }

    void DropShield()
    {
        if (shield != null)
        {
            // Detach the shield and make it disappear
            shield.transform.SetParent(null);
            shield.GetComponent<Rigidbody2D>().isKinematic = false; // Enable physics
            shield.SetActive(false);
            shieldPickedUp = false;

            // Announce drop
            if (pickupMessageUI != null)
            {
                pickupMessageUI.SetActive(false);
            }
        }
    }
}
