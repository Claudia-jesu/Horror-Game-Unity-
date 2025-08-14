using UnityEngine;

/*public class PlayerShooting : MonoBehaviour
{
    public Camera fpsCam;             // Your player's camera
    public float range = 100f;        // Shooting range
    public int damage = 9999;         // Very high damage to ensure one shot kills
    public ParticleSystem muzzleFlash; // Optional effect

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Space bar to shoot
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (muzzleFlash != null)
            muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Debug.Log("Hit: " + hit.transform.name);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Instantly lethal
            }
        }
    }
}
*/


public class PlayerShooting : MonoBehaviour
{
    public Camera fpsCam;             // Your player's camera
    public float range = 100f;        // Shooting range
    public int damage = 9999;         // Very high damage to ensure one shot kills
    public ParticleSystem muzzleFlash; // Optional effect
    public GameObject gunArms;        // Reference to player's gun arms

    void Update()
    {
        // Only allow shooting if gun arms are active
        if (gunArms != null && gunArms.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Space bar to shoot
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (muzzleFlash != null)
            muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Debug.Log("Hit: " + hit.transform.name);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Instantly lethal
            }
        }
    }
}
