/*using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenChest()
    {
        anim.SetBool("open", true);
    }
}*/


using UnityEngine;
using TMPro; // For TextMeshPro

public class Chest : MonoBehaviour
{
    public string chestMessage; // Message for THIS chest
    public TextMeshProUGUI messageUI; // Reference to the UI text
    public float messageDuration = 3f; // Seconds to display

    private Animator anim;
    private bool isOpened = false;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Ensure message is hidden at start
        if (messageUI != null)
            messageUI.text = "";
    }

    public void OpenChest()
    {
        if (!isOpened) // Prevent re-opening
        {
            anim.SetBool("open", true);
            isOpened = true;

            if (messageUI != null)
                StartCoroutine(ShowMessage());
        }
    }

    private System.Collections.IEnumerator ShowMessage()
    {
        messageUI.text = chestMessage;
        yield return new WaitForSeconds(messageDuration);
        messageUI.text = "";
    }
}

