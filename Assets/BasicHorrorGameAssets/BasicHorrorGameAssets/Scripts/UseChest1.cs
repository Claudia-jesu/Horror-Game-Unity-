using UnityEngine;

public class UseChest1 : MonoBehaviour
{
    public GameObject handUI;
    public GameObject objToActivate;

    private bool inReach = false;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        handUI.SetActive(false);
        if (objToActivate != null)
            objToActivate.SetActive(false);
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
            anim.SetBool("open", true);
            handUI.SetActive(false);

            if (objToActivate != null)
                objToActivate.SetActive(true);
        }
    }
}
