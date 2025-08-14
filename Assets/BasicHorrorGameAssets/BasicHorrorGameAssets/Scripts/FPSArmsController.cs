using UnityEngine;

public class FPSArmsController : MonoBehaviour
{
    [Header("Player Camera")]
    public Camera playerCamera;

    [Header("Arms Slots")]
    public GameObject gunArms;
    public GameObject keyArms;
    public GameObject lanternArms;

    [Header("Collision Settings")]
    public LayerMask collisionLayers;
    public float distanceFromCamera = 0.5f;

    private GameObject activeArm;

    void Update()
    {
        // Always keep active arm in front of camera
        if (activeArm != null)
        {
            Vector3 targetPos = playerCamera.transform.position + playerCamera.transform.forward * distanceFromCamera;
            activeArm.transform.position = targetPos;
            activeArm.transform.rotation = playerCamera.transform.rotation;
        }
    }

    public void ActivateArm(string armType)
    {
        // Disable all arms first
        gunArms.SetActive(false);
        keyArms.SetActive(false);
        lanternArms.SetActive(false);

        // Enable the selected arm
        switch (armType)
        {
            case "Gun":
                gunArms.SetActive(true);
                activeArm = gunArms;
                break;
            case "Key":
                keyArms.SetActive(true);
                activeArm = keyArms;
                break;
            case "Lantern":
                lanternArms.SetActive(true);
                activeArm = lanternArms;
                break;
        }
    }
}
