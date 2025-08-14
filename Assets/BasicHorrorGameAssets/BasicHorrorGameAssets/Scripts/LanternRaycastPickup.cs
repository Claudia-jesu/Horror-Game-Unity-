
/*using UnityEngine;

public class LanternRaycastPickup : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public GameObject handUI;
    public GameObject lanternArms;

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

                if (canInteract && Input.GetButtonDown("Interact") && currentChest != null)
                {
                    Animator chestAnim = hit.collider.GetComponent<Animator>();
                    if (chestAnim != null)
                    {
                        chestAnim.SetBool("open", true);
                    }

                    handUI.SetActive(false);
                    canInteract = false;

                    // Activate lantern arms ONLY if chest contains lantern
                    if (currentChest.chestItem == ChestItem.Lantern)
                    {
                        lanternArms.SetActive(true);
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
using UnityEngine;

public class LanternRaycastPickup : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public GameObject handUI;
    public GameObject lanternArms;

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

                if (canInteract && Input.GetButtonDown("Interact") && currentChest != null)
                {
                    Animator chestAnim = hit.collider.GetComponent<Animator>();
                    if (chestAnim != null)
                    {
                        chestAnim.SetBool("open", true);
                    }

                    handUI.SetActive(false);
                    canInteract = false;

                    if (currentChest.chestItem == ChestItem.Lantern)
                    {
                        lanternArms.SetActive(true);

                        // Destroy the lantern object inside the chest if assigned
                        if (currentChest.itemToDestroy != null)
                        {
                            Destroy(currentChest.itemToDestroy);
                        }
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
