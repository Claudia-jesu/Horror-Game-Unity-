/*using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy.
    private int currentHealth; // Current health of the enemy.

    // Called when the enemy is initialized.
    private void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum health.
    }

    // Function to apply damage to the enemy.
    public void TakeDamage(int damageAmount)
    {
        // Reduce the current health by the damage amount.
        currentHealth -= damageAmount;

        // Check if the enemy's health has reached zero or below.
        if (currentHealth <= 0)
        {
            Die(); // Call the function to handle the enemy's death.
        }
    }

    // Function to handle the enemy's death.
    private void Die()
    {
        // Perform any death-related actions here, such as playing death animations, spawning effects, or removing the enemy from the scene.
        // You can customize this method based on your game's requirements.

        // For example, you might destroy the enemy GameObject:
        gameObject.GetComponent<Animator>().SetBool("Death", true);
    }
}*/
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator; // Assign in Inspector
    public bool isDead = false;

    private EnemyController enemyController;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        enemyController = GetComponent<EnemyController>();
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        isDead = true;
        Die();
    }

    private void Die()
    {
        // Play death animation
        if (animator != null)
            animator.SetBool("Death", true);

        // Stop enemy movement
        if (enemyController != null)
            enemyController.enabled = false;

        // Optional: disable NavMeshAgent if using it
        var agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null)
            agent.enabled = false;

        // Destroy after animation
        Destroy(gameObject, 3f);
    }
}

