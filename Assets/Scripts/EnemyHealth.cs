using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health value
    private int currentHealth; // Current health value

    public Slider healthSlider; // Reference to the health bar slider
    public GameObject[] itemDropPrefab;

    private void Start()
    {
        currentHealth = maxHealth; // Set the initial health value

        // Update the health bar UI
        UpdateHealthUI();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Decrease the health value by the damage amount

        // Check if the health value dropped below 0
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        // Update the health bar UI
        UpdateHealthUI();
    }

    private void Die()
    {
        int randomIndex = Random.Range(0, itemDropPrefab.Length);

        // Instantiate the item drop prefab at the enemy's position
        Instantiate(itemDropPrefab[randomIndex], transform.position, Quaternion.identity);

        Destroy(gameObject); // Destroy the enemy object
    }

    private void UpdateHealthUI()
    {
        // Update the value of the health bar slider
        healthSlider.value = (float)currentHealth / maxHealth;
    }
}
