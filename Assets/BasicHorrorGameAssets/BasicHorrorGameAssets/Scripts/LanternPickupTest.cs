using UnityEngine;

public class LanternPickupTest : MonoBehaviour
{
    public GameObject LanternArms; // Assign your player lantern arms here
    public GameObject handUI;      // Assign your hand UI here

    private bool inReach = false;

    void Start()
    {
        handUI.SetActive(false);
        LanternArms.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger!");
            inReach = true;
            handUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger!");
            inReach = false;
            handUI.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed, activating LanternArms!");
            LanternArms.SetActive(true);
            handUI.SetActive(false);
        }
    }
}

