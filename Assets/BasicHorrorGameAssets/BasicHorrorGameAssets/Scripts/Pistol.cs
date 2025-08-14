using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Pistol : MonoBehaviour
{
    public int maxAmmoInMag = 20;       // Maximum ammo capacity in the magazine
    public int maxAmmoInStorage = 30;   // Maximum ammo capacity in the storage
    public float shootCooldown = 0.1f;  // Cooldown time between shots
    public float reloadCooldown = 0.1f;  // Cooldown time between shots
    private float switchCooldown = 0.1f;  // Cooldown time between shots
    public float shootRange = 100f;     // Range of the raycast

    public ParticleSystem impactEffect; // Particle effect for impact

    public int currentAmmoInMag;       // Current ammo in the magazine
    public int currentAmmoInStorage;   // Current ammo in the storage
    public int damager;   // Current ammo in the storage
    public bool canShoot = true;       // Flag to check if shooting is allowed
    public bool canSwitch = true;       // Flag to check if shooting is allowed
    private bool isReloading = false;   // Flag to check if reloading is in progress
    private float shootTimer;           // Timer for shoot cooldown

    public Transform cartridgeEjectionPoint; // Ejection point of the cartridge
    public GameObject cartridgePrefab; // Prefab of the cartridge
    public float cartridgeEjectionForce = 5f; // Force applied to the cartridge



    public Animator gun;
    public ParticleSystem muzzleFlash;
    public GameObject muzzleFlashLight;
    public AudioSource shoot;

    void Start()
    {
        currentAmmoInMag = maxAmmoInMag;
        currentAmmoInStorage = maxAmmoInStorage;
        canSwitch = true;
        muzzleFlashLight.SetActive(false);
    }

    void Update()
    {

        // Update current ammo counts
        currentAmmoInMag = Mathf.Clamp(currentAmmoInMag, 0, maxAmmoInMag);
        currentAmmoInStorage = Mathf.Clamp(currentAmmoInStorage, 0, maxAmmoInStorage);

        // Check for shoot input
        if (Input.GetKeyDown(KeyCode.Space) && canShoot && !isReloading)

            {
                switchCooldown = shootCooldown;
            Shoot();
        }

        // Check for reload input
        if (Input.GetKeyDown(KeyCode.R))
        {
            switchCooldown = reloadCooldown;
            Reload();
        }

        // Update the shoot timer
        if (shootTimer > 0f)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        // Check if there is ammo in the magazine
        if (currentAmmoInMag > 0 && shootTimer <= 0f)
        {
            canSwitch = false;
            shoot.Play();
            muzzleFlash.Play();
            muzzleFlashLight.SetActive(true);
            gun.SetBool("shoot", true);

            // Perform the shoot action
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, shootRange))
            {
                // Check if the hit object has the "enemy" tag
                if (hit.collider.CompareTag("Enemy"))
                {
                    // Get the EnemyHealth component from the hit object
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

                    // Check if the enemy has the EnemyHealth component
                    if (enemyHealth != null)
                    {
                        // Apply damage to the enemy
                        enemyHealth.TakeDamage(damager); // Replace 'damager' with the actual damage value.
                    }
                }

                // Instantiate impact effect at the hit point
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

            // Instantiate the empty cartridge
            GameObject cartridge = Instantiate(cartridgePrefab, cartridgeEjectionPoint.position, cartridgeEjectionPoint.rotation);
            Rigidbody cartridgeRigidbody = cartridge.GetComponent<Rigidbody>();

            // Apply force to eject the cartridge
            cartridgeRigidbody.AddForce(cartridgeEjectionPoint.right * cartridgeEjectionForce, ForceMode.Impulse);

            StartCoroutine(endAnimations());
            StartCoroutine(endLight());
            StartCoroutine(canswitchshoot());

            switchCooldown -= Time.deltaTime;

            // Reduce ammo count
            currentAmmoInMag--;

            // Start the shoot cooldown
            shootTimer = shootCooldown;
        }
        else
        {
            // Out of ammo in the magazine or shoot on cooldown
            Debug.Log("Cannot shoot");
        }
    }

    void Reload()
    {
        switchCooldown -= Time.deltaTime;
        // Check if already reloading or out of ammo in the storage
        if (isReloading || currentAmmoInStorage <= 0)
            return;

        // Calculate the number of bullets to reload
        int bulletsToReload = maxAmmoInMag - currentAmmoInMag;

        // Check if there is enough ammo in the storage for reloading
        if (bulletsToReload > 0)
        {

            gun.SetBool("reload", true);
            StartCoroutine(endAnimations());


            // Determine the actual number of bullets to reload based on available ammo
            int bulletsAvailable = Mathf.Min(bulletsToReload, currentAmmoInStorage);

            // Update ammo counts
            currentAmmoInMag += bulletsAvailable;
            currentAmmoInStorage -= bulletsAvailable;

            Debug.Log("Reloaded " + bulletsAvailable + " bullets");

            // Start the reload cooldown
            StartCoroutine(ReloadCooldown());
        }
        else
        {
            Debug.Log("Cannot reload");
        }
    }

    IEnumerator ReloadCooldown()
    {
        isReloading = true;
        canShoot = false;
        canSwitch = false;

        yield return new WaitForSeconds(reloadCooldown);

        isReloading = false;
        canShoot = true;
        canSwitch = true;
    }

    IEnumerator endAnimations()
    {
        yield return new WaitForSeconds(.1f);
        gun.SetBool("shoot", false);
        gun.SetBool("reload", false);


    }

    IEnumerator endLight()
    {
        yield return new WaitForSeconds(.1f);
        muzzleFlashLight.SetActive(false);
    }

    IEnumerator canswitchshoot()
    {
        yield return new WaitForSeconds(shootCooldown);
        canSwitch = true;
    }

}*/




/*
public class Pistol : MonoBehaviour
{
    public int maxAmmoInMag = 20;       // Maximum ammo capacity in the magazine
    public int maxAmmoInStorage = 30;   // Maximum ammo capacity in the storage
    public float shootCooldown = 0.1f;  // Cooldown time between shots
    public float reloadCooldown = 0.1f; // Cooldown time between shots
    private float switchCooldown = 0.1f;  // Cooldown time between shots
    public float shootRange = 100f;     // Range of the raycast

    public ParticleSystem impactEffect; // Particle effect for impact

    public int currentAmmoInMag;       // Current ammo in the magazine
    public int currentAmmoInStorage;   // Current ammo in the storage
    public int damager;   // Damage amount
    public bool canShoot = true;       // Flag to check if shooting is allowed
    public bool canSwitch = true;       // Flag to check if switching allowed
    private bool isReloading = false;   // Flag to check if reloading is in progress
    private float shootTimer;           // Timer for shoot cooldown

    public Transform cartridgeEjectionPoint; // Ejection point of the cartridge
    public GameObject cartridgePrefab; // Prefab of the cartridge
    public float cartridgeEjectionForce = 5f; // Force applied to the cartridge

    public Animator gun;
    public ParticleSystem muzzleFlash;
    public GameObject muzzleFlashLight;
    public AudioSource shoot;

    // Static flag to know if gun is picked up
    public static bool gunIsPickedUp = false;

    void Start()
    {
        currentAmmoInMag = maxAmmoInMag;
        currentAmmoInStorage = maxAmmoInStorage;
        canSwitch = true;
        muzzleFlashLight.SetActive(false);

        // Initially disable shooting until gun is picked up
        canShoot = false;
    }

    void Update()
    {
        // Update current ammo counts
        currentAmmoInMag = Mathf.Clamp(currentAmmoInMag, 0, maxAmmoInMag);
        currentAmmoInStorage = Mathf.Clamp(currentAmmoInStorage, 0, maxAmmoInStorage);

        // Only allow shooting if gun is picked up
        if (gunIsPickedUp && canShoot && Input.GetKeyDown(KeyCode.Space) && !isReloading)
        {
            switchCooldown = shootCooldown;
            Shoot();
        }

        // Reload input allowed regardless of gunIsPickedUp, or you can add check if you want

        if (Input.GetKeyDown(KeyCode.R))
        {
            switchCooldown = reloadCooldown;
            Reload();
        }

        // Update the shoot timer
        if (shootTimer > 0f)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        if (currentAmmoInMag > 0 && shootTimer <= 0f)
        {
            canSwitch = false;
            shoot.Play();
            muzzleFlash.Play();
            muzzleFlashLight.SetActive(true);
            gun.SetBool("shoot", true);

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, shootRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damager);
                    }
                }
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

            GameObject cartridge = Instantiate(cartridgePrefab, cartridgeEjectionPoint.position, cartridgeEjectionPoint.rotation);
            Rigidbody cartridgeRigidbody = cartridge.GetComponent<Rigidbody>();
            cartridgeRigidbody.AddForce(cartridgeEjectionPoint.right * cartridgeEjectionForce, ForceMode.Impulse);

            StartCoroutine(endAnimations());
            StartCoroutine(endLight());
            StartCoroutine(canswitchshoot());

            switchCooldown -= Time.deltaTime;

            currentAmmoInMag--;
            shootTimer = shootCooldown;
        }
        else
        {
            Debug.Log("Cannot shoot");
        }
    }

    void Reload()
    {
        switchCooldown -= Time.deltaTime;
        if (isReloading || currentAmmoInStorage <= 0)
            return;

        int bulletsToReload = maxAmmoInMag - currentAmmoInMag;

        if (bulletsToReload > 0)
        {
            gun.SetBool("reload", true);
            StartCoroutine(endAnimations());

            int bulletsAvailable = Mathf.Min(bulletsToReload, currentAmmoInStorage);

            currentAmmoInMag += bulletsAvailable;
            currentAmmoInStorage -= bulletsAvailable;

            Debug.Log("Reloaded " + bulletsAvailable + " bullets");

            StartCoroutine(ReloadCooldown());
        }
        else
        {
            Debug.Log("Cannot reload");
        }
    }

    IEnumerator ReloadCooldown()
    {
        isReloading = true;
        canShoot = false;
        canSwitch = false;

        yield return new WaitForSeconds(reloadCooldown);

        isReloading = false;
        canShoot = true;
        canSwitch = true;
    }

    IEnumerator endAnimations()
    {
        yield return new WaitForSeconds(.1f);
        gun.SetBool("shoot", false);
        gun.SetBool("reload", false);
    }

    IEnumerator endLight()
    {
        yield return new WaitForSeconds(.1f);
        muzzleFlashLight.SetActive(false);
    }

    IEnumerator canswitchshoot()
    {
        yield return new WaitForSeconds(shootCooldown);
        canSwitch = true;
    }
}

*/




public class Pistol : MonoBehaviour
{
    public int maxAmmoInMag = 20;       // Maximum ammo capacity in the magazine
    public int maxAmmoInStorage = 30;   // Maximum ammo capacity in the storage
    public float shootCooldown = 0.1f;  // Cooldown time between shots
    public float reloadCooldown = 0.1f; // Cooldown time between shots
    private float switchCooldown = 0.1f;  // Cooldown time between shots
    public float shootRange = 100f;     // Range of the raycast

    public ParticleSystem impactEffect; // Particle effect for impact

    public int currentAmmoInMag;       // Current ammo in the magazine
    public int currentAmmoInStorage;   // Current ammo in the storage
    public int damager;   // Damage amount
    public bool canShoot = false;      // Flag to check if shooting is allowed
    public bool canSwitch = true;      // Flag to check if switching allowed
    private bool isReloading = false;  // Flag to check if reloading is in progress
    private float shootTimer;          // Timer for shoot cooldown

    public Transform cartridgeEjectionPoint; // Ejection point of the cartridge
    public GameObject cartridgePrefab;        // Prefab of the cartridge
    public float cartridgeEjectionForce = 5f; // Force applied to the cartridge

    public Animator gun;
    public ParticleSystem muzzleFlash;
    public GameObject muzzleFlashLight;
    public AudioSource shoot;

    // Static flag for gun pickup status
    public static bool gunIsPickedUp = false;

    // Reference to gunArms GameObject to check if gun is active
    public GameObject gunArms;

    void Start()
    {
        currentAmmoInMag = maxAmmoInMag;
        currentAmmoInStorage = maxAmmoInStorage;
        canSwitch = true;
        muzzleFlashLight.SetActive(false);

        canShoot = false; // disable shooting initially
    }

    void Update()
    {
        // Clamp ammo values
        currentAmmoInMag = Mathf.Clamp(currentAmmoInMag, 0, maxAmmoInMag);
        currentAmmoInStorage = Mathf.Clamp(currentAmmoInStorage, 0, maxAmmoInStorage);

        // Update canShoot based on gun arms active and reloading state
        canShoot = (gunArms != null && gunArms.activeSelf) && !isReloading;

        // Shoot only if space pressed, canShoot true, and cooldown ready
        if (canShoot && Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, shootRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Shoot(hit);
                }
                else
                {
                    Debug.Log("Enemy not in sight - cannot shoot.");
                }
            }
            else
            {
                Debug.Log("No target in sight to shoot.");
            }
        }

        // Reload input
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        // Cooldown timer update
        if (shootTimer > 0f)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    void Shoot(RaycastHit hit)
    {
        if (currentAmmoInMag > 0)
        {
            canSwitch = false;
            shoot.Play();
            muzzleFlash.Play();
            muzzleFlashLight.SetActive(true);
            gun.SetBool("shoot", true);

            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damager);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            GameObject cartridge = Instantiate(cartridgePrefab, cartridgeEjectionPoint.position, cartridgeEjectionPoint.rotation);
            Rigidbody cartridgeRigidbody = cartridge.GetComponent<Rigidbody>();
            cartridgeRigidbody.AddForce(cartridgeEjectionPoint.right * cartridgeEjectionForce, ForceMode.Impulse);

            StartCoroutine(endAnimations());
            StartCoroutine(endLight());
            StartCoroutine(canswitchshoot());

            switchCooldown -= Time.deltaTime;

            currentAmmoInMag--;
            shootTimer = shootCooldown;
        }
        else
        {
            Debug.Log("No ammo to shoot.");
        }
    }

    void Reload()
    {
        switchCooldown -= Time.deltaTime;
        if (isReloading || currentAmmoInStorage <= 0)
            return;

        int bulletsToReload = maxAmmoInMag - currentAmmoInMag;

        if (bulletsToReload > 0)
        {
            gun.SetBool("reload", true);
            StartCoroutine(endAnimations());

            int bulletsAvailable = Mathf.Min(bulletsToReload, currentAmmoInStorage);

            currentAmmoInMag += bulletsAvailable;
            currentAmmoInStorage -= bulletsAvailable;

            Debug.Log("Reloaded " + bulletsAvailable + " bullets");

            StartCoroutine(ReloadCooldown());
        }
        else
        {
            Debug.Log("Cannot reload");
        }
    }

    IEnumerator ReloadCooldown()
    {
        isReloading = true;
        canShoot = false;
        canSwitch = false;

        yield return new WaitForSeconds(reloadCooldown);

        isReloading = false;
        canShoot = (gunArms != null && gunArms.activeSelf);
        canSwitch = true;
    }

    IEnumerator endAnimations()
    {
        yield return new WaitForSeconds(.1f);
        gun.SetBool("shoot", false);
        gun.SetBool("reload", false);
    }

    IEnumerator endLight()
    {
        yield return new WaitForSeconds(.1f);
        muzzleFlashLight.SetActive(false);
    }

    IEnumerator canswitchshoot()
    {
        yield return new WaitForSeconds(shootCooldown);
        canSwitch = true;
    }
}

