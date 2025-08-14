using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorInteraction : MonoBehaviour
{
    public string nextSceneName = "GameOverScene"; // Set your Game Over scene name
    public float delay = 0.5f; // Optional delay
    public GameObject fadeout; // Optional fadeout effect

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object touching the door is tagged as "Key"
        if (other.CompareTag("Key"))
        {
            StartCoroutine(FadeAndLoad());
        }
    }

    private IEnumerator FadeAndLoad()
    {
        if (fadeout != null)
            fadeout.SetActive(true);

        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
