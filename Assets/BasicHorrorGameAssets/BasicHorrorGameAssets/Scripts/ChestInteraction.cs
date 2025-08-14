using UnityEngine;

/*public class ChestInteraction : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public GameObject handUI;

    public GameObject lanternArms;   // Player’s lantern arms to activate on pickup

    private bool canInteract = false;
    private ChestContents currentChest = null;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayer))
        {
            if (hit.collider.CompareTag("Chest"))
            {
                handUI.SetActive(true);
                canInteract = true;

                currentChest = hit.collider.GetComponent<ChestContents>();
                Animator chestAnim = hit.collider.GetComponent<Animator>();

                if (Input.GetButtonDown("Interact") && currentChest != null)
                {
                    if (!currentChest.isOpen)
                    {
                        // Open chest and show item inside
                        chestAnim?.SetBool("open", true);

                        if (currentChest.itemToDestroy != null)
                            currentChest.itemToDestroy.SetActive(true); // Show the item in chest

                        currentChest.isOpen = true;
                    }
                    else
                    {
                        // Chest is open, so pick up the item
                        if (currentChest.chestItem == ChestItem.Lantern)
                        {
                            lanternArms.SetActive(true);  // Show lantern arms on player

                            if (currentChest.itemToDestroy != null)
                                Destroy(currentChest.itemToDestroy); // Remove lantern from chest
                        }

                        handUI.SetActive(false);
                        canInteract = false;
                        currentChest = null;
                    }
                }
            }
            else
            {
                handUI.SetActive(false);
                canInteract = false;
                currentChest = null;
            }
        }
        else
        {
            handUI.SetActive(false);
            canInteract = false;
            currentChest = null;
        }
    }
}
*/


/*

public class ChestInteraction : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public GameObject handUI;

    public GameObject lanternArms;   // Player’s lantern arms to activate on pickup
    public GameObject gunArms;       // Player’s gun arms to activate on pickup

    private bool canInteract = false;
    private ChestContents currentChest = null;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayer))
        {
            if (hit.collider.CompareTag("Chest"))
            {
                handUI.SetActive(true);
                canInteract = true;

                currentChest = hit.collider.GetComponent<ChestContents>();
                Animator chestAnim = hit.collider.GetComponent<Animator>();

                if (Input.GetButtonDown("Interact") && currentChest != null)
                {
                    if (!currentChest.isOpen)
                    {
                        chestAnim?.SetBool("open", true);

                        if (currentChest.itemToDestroy != null)
                            currentChest.itemToDestroy.SetActive(true);

                        currentChest.isOpen = true;

                        Debug.Log($"Chest opened. Item: {currentChest.chestItem}");
                    }
                    else
                    {
                        Debug.Log($"Picking up item: {currentChest.chestItem}");

                        switch (currentChest.chestItem)
                        {
                            case ChestItem.Lantern:
                                if (lanternArms != null)
                                {
                                    lanternArms.SetActive(true);
                                    Debug.Log("Lantern arms activated.");
                                }
                                else Debug.LogWarning("Lantern arms reference not set!");
                                break;

                            case ChestItem.Gun:
                                if (gunArms != null)
                                {
                                    gunArms.SetActive(true);
                                    Debug.Log("Gun arms activated.");
                                }
                                else Debug.LogWarning("Gun arms reference not set!");
                                break;

                            default:
                                Debug.Log("No arms to activate for empty or unknown item.");
                                break;
                        }

                        if (currentChest.itemToDestroy != null)
                        {
                            Destroy(currentChest.itemToDestroy);
                            Debug.Log("Chest item destroyed after pickup.");
                        }

                        handUI.SetActive(false);
                        canInteract = false;
                        currentChest = null;
                    }
                }
            }
            else
            {
                handUI.SetActive(false);
                canInteract = false;
                currentChest = null;
            }
        }
        else
        {
            handUI.SetActive(false);
            canInteract = false;
            currentChest = null;
        }
    }
}*/
/*public class ChestInteraction : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public GameObject handUI;

    public GameObject lanternArms;   // Player’s lantern arms to activate on pickup
    public GameObject gunArms;       // Player’s gun arms to activate on pickup
    public GameObject keyArms;       // Player’s key arms to activate on pickup

    private bool canInteract = false;
    private ChestContents currentChest = null;

    private bool hasKey = false; // Tracks if key has been picked up

    void Update()
    {
        // Handle G/K switching (only if player has the key)
        if (hasKey)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (gunArms != null)
                {
                    gunArms.SetActive(true);
                    keyArms.SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (keyArms != null)
                {
                    keyArms.SetActive(true);
                    gunArms.SetActive(false);
                }
            }
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayer))
        {
            if (hit.collider.CompareTag("Chest"))
            {
                handUI.SetActive(true);
                canInteract = true;

                currentChest = hit.collider.GetComponent<ChestContents>();
                Animator chestAnim = hit.collider.GetComponent<Animator>();

                if (Input.GetButtonDown("Interact") && currentChest != null)
                {
                    if (!currentChest.isOpen)
                    {
                        chestAnim?.SetBool("open", true);

                        if (currentChest.itemToDestroy != null)
                            currentChest.itemToDestroy.SetActive(true);

                        currentChest.isOpen = true;

                        Debug.Log($"Chest opened. Item: {currentChest.chestItem}");
                    }
                    else
                    {
                        Debug.Log($"Picking up item: {currentChest.chestItem}");

                        switch (currentChest.chestItem)
                        {
                            case ChestItem.Lantern:
                                if (lanternArms != null)
                                {
                                    lanternArms.SetActive(true);
                                    Debug.Log("Lantern arms activated.");
                                }
                                else Debug.LogWarning("Lantern arms reference not set!");
                                break;

                            case ChestItem.Gun:
                                if (gunArms != null)
                                {
                                    gunArms.SetActive(true);
                                    Debug.Log("Gun arms activated.");
                                }
                                else Debug.LogWarning("Gun arms reference not set!");
                                break;

                            case ChestItem.Key: // NEW: Key arms pickup
                                if (keyArms != null)
                                {
                                    keyArms.SetActive(true);
                                    gunArms.SetActive(false); // Hide gun arms on pickup
                                    hasKey = true; // Player now has the key
                                    Debug.Log("Key arms activated.");
                                }
                                else Debug.LogWarning("Key arms reference not set!");
                                break;

                            default:
                                Debug.Log("No arms to activate for empty or unknown item.");
                                break;
                        }

                        if (currentChest.itemToDestroy != null)
                        {
                            Destroy(currentChest.itemToDestroy);
                            Debug.Log("Chest item destroyed after pickup.");
                        }

                        handUI.SetActive(false);
                        canInteract = false;
                        currentChest = null;
                    }
                }
            }
            else
            {
                handUI.SetActive(false);
                canInteract = false;
                currentChest = null;
            }
        }
        else
        {
            handUI.SetActive(false);
            canInteract = false;
            currentChest = null;
        }
    }
}*/


public class ChestInteraction : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public GameObject handUI;

    public GameObject lanternArms;   // Player’s lantern arms to activate on pickup
    public GameObject gunArms;       // Player’s gun arms to activate on pickup
    public GameObject keyArms;       // Player’s key arms to activate on pickup

    private bool canInteract = false;
    private ChestContents currentChest = null;

    private bool hasKey = false; // Tracks if key has been picked up

    void Update()
    {
        // Handle G/K switching (only if player has the key)
        if (hasKey)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (gunArms != null)
                {
                    gunArms.SetActive(true);
                    keyArms.SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (keyArms != null)
                {
                    keyArms.SetActive(true);
                    gunArms.SetActive(false);
                }
            }
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayer))
        {
            if (hit.collider.CompareTag("Chest"))
            {
                handUI.SetActive(true);
                canInteract = true;

                currentChest = hit.collider.GetComponent<ChestContents>();
                Animator chestAnim = hit.collider.GetComponent<Animator>();

                if (Input.GetButtonDown("Interact") && currentChest != null)
                {
                    if (!currentChest.isOpen)
                    {
                        chestAnim?.SetBool("open", true);

                        if (currentChest.itemToDestroy != null)
                            currentChest.itemToDestroy.SetActive(true);

                        currentChest.isOpen = true;

                        Debug.Log($"Chest opened. Item: {currentChest.chestItem}");
                    }
                    else
                    {
                        Debug.Log($"Picking up item: {currentChest.chestItem}");

                        switch (currentChest.chestItem)
                        {
                            case ChestItem.Lantern:
                                if (lanternArms != null)
                                {
                                    lanternArms.SetActive(true);
                                    Debug.Log("Lantern arms activated.");
                                }
                                else Debug.LogWarning("Lantern arms reference not set!");
                                break;

                            case ChestItem.Gun:
                                if (gunArms != null)
                                {
                                    gunArms.SetActive(true);
                                    Debug.Log("Gun arms activated.");

                                    // Inform the Pistol script that gun is picked up and shooting allowed
                                    Pistol.gunIsPickedUp = true;
                                }
                                else Debug.LogWarning("Gun arms reference not set!");
                                break;

                            case ChestItem.Key: // NEW: Key arms pickup
                                if (keyArms != null)
                                {
                                    keyArms.SetActive(true);
                                    gunArms.SetActive(false); // Hide gun arms on pickup
                                    hasKey = true; // Player now has the key
                                    //GetComponent<PlayerKeyHolder>().hasKey = true;
                                    Debug.Log("Key arms activated.");
                                }
                                else Debug.LogWarning("Key arms reference not set!");
                                break;

                            default:
                                Debug.Log("No arms to activate for empty or unknown item.");
                                break;
                        }

                        if (currentChest.itemToDestroy != null)
                        {
                            Destroy(currentChest.itemToDestroy);
                            Debug.Log("Chest item destroyed after pickup.");
                        }

                        handUI.SetActive(false);
                        canInteract = false;
                        currentChest = null;
                    }
                }
            }
            else
            {
                handUI.SetActive(false);
                canInteract = false;
                currentChest = null;
            }
        }
        else
        {
            handUI.SetActive(false);
            canInteract = false;
            currentChest = null;
        }
    }
}


