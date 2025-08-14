

/*public class KillPlayer : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load
    public float delay = 0.5f; // Delay in seconds before loading the next scene
    public GameObject fadeout;

    private bool playerInsideTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
            fadeout.SetActive(true);
            Invoke("LoadNextScene", delay);
        }
    }


    private void LoadNextScene()
    {
        if (playerInsideTrigger)
        {
            // Load the next scene by name
            SceneManager.LoadScene(nextSceneName);
        }
    }
}*/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    public string nextSceneName;
    public float delay = 0.5f;
    public GameObject fadeout;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeAndLoad());
        }
    }

    private IEnumerator FadeAndLoad()
    {
        fadeout.SetActive(true);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}

