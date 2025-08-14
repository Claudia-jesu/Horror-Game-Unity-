using UnityEngine;

public class ArmsCollisionPreventer : MonoBehaviour
{
    public GameObject arm;            // Assign the arm (gun, lantern, or key)
    public float armDistance = 1.0f;  // Default distance from camera
    public float wallBuffer = 0.05f;  // Small offset to avoid clipping into walls

    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (arm == null || playerCamera == null) return;

        // Default target position in front of camera
        Vector3 targetPos = playerCamera.transform.position + playerCamera.transform.forward * armDistance;

        // Raycast to prevent clipping through walls
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, armDistance))
        {
            targetPos = hit.point - playerCamera.transform.forward * wallBuffer;
        }

        // Update position and rotation
        arm.transform.position = targetPos;
        arm.transform.rotation = playerCamera.transform.rotation;
    }
}
