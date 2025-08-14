/*using UnityEngine;

public class ChestRaycast : MonoBehaviour
{
    public float interactDistance = 3f; // How close player must be
    public LayerMask interactLayer; // Layer for chests
    public GameObject handUI; // Hand icon UI

    private Animator chestAnim;
    private bool isOpen = false;

    void Update()
    {
        RaycastHit hit;
        // Shoot ray from camera forward
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactLayer))
        {
            // If the object has an Animator and tag "Chest"
            if (hit.collider.CompareTag("Chest"))
            {
                if (!isOpen)
                {
                    handUI.SetActive(true);

                    // Press E to interact
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        chestAnim = hit.collider.GetComponent<Animator>();
                        if (chestAnim != null)
                        {
                            chestAnim.Play("OpenChest");
                            isOpen = true;
                            handUI.SetActive(false);
                        }
                    }
                }
            }
        }
        else
        {
            // Hide UI if not looking at a chest
            handUI.SetActive(false);
        }
    }
}*/

using UnityEngine;

public class ChestRaycast : MonoBehaviour
{
    public float rayDistance = 3f;
    public LayerMask interactableLayer;
    public GameObject handUI;

    private Animator currentChestAnimator;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            // Show Hand UI when looking at a chest
            handUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentChestAnimator = hit.collider.GetComponent<Animator>();
                if (currentChestAnimator != null)
                {
                    currentChestAnimator.SetBool("open", true);
                }
            }
        }
        else
        {
            // Hide Hand UI if not looking at a chest
            handUI.SetActive(false);
        }
    }
}

