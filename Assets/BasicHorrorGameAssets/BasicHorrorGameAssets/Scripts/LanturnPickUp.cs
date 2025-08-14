using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class LanturnPickUp : MonoBehaviour
{
    private GameObject OB;
    public GameObject handUI;
    public GameObject lanturn;


    private bool inReach;


    void Start()
    {
        OB = this.gameObject;

        handUI.SetActive(false);

        lanturn.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            handUI.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            handUI.SetActive(false);
        }
    }

    void Update()
    {


        if (inReach && Input.GetButtonDown("Interact"))
        {
            handUI.SetActive(false);
            lanturn.SetActive(true);
            StartCoroutine(end());
        }
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(.01f);
        Destroy(OB);
    }
}*/

/*
public class LanternPickUp : MonoBehaviour
{
    public GameObject handUI;
    public GameObject lantern;

    private bool inReach = false;

    void Start()
    {
        handUI.SetActive(false);
        lantern.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inReach = true;
            handUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inReach = false;
            handUI.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            handUI.SetActive(false);
            lantern.SetActive(true);
            Destroy(gameObject, 0.01f);  // Destroys chest after pickup
        }
    }
}*/

public class LanturnPickUp : MonoBehaviour
{
    public GameObject handUI;         // UI hand icon when near chest
    public GameObject LanternArms;    // The lantern model attached to player (initially disabled)

    private bool inReach = false;
    private bool pickedUp = false;    // To prevent multiple pickups

    void Start()
    {
        handUI.SetActive(false);
        // LanternArms should be disabled by default in the inspector
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inReach = true;
            handUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inReach = false;
            handUI.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && !pickedUp && Input.GetKeyDown(KeyCode.E))
        {
            pickedUp = true;                 // Mark as picked up
            handUI.SetActive(false);        // Hide hand UI
            LanternArms.SetActive(true);    // Show lantern in player’s hand
        }
    }
}



