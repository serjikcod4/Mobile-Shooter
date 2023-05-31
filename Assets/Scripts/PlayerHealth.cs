using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health value
    public Slider healthSlider; // Reference to the Slider component for displaying the health bar

    private int currentHealth; // Current health value
    private Player playerScript;

    private void Start()
    {
        playerScript = GetComponent<Player>();
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
        playerScript.playerIsDead = true;
        MainManager.Instance.ActivateRestartMenu();
    }

    private void UpdateHealthUI()
    {
        // Update the value of the health bar
        healthSlider.value = (float)currentHealth / maxHealth;

        // Additional effects, color changes, etc. can be added based on the current health value
    }
}
