using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 5f; // Movement speed of the enemy
    public float attackDistance = 2f; // Distance at which the enemy will start attacking
    public float approachDistance = 10f; // Distance at which the enemy will start approaching the player
    public float attackDelay = 1f; // Delay between attacks
    public int damage = 10;

    private bool isAttacking = false; // Flag to track if the enemy is currently attacking
    private bool canAttack = true; // Flag to control the attack delay
    private GameObject player; // Reference to the player's GameObject

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Calculate the distance between the enemy and player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackDistance)
        {
            // Enemy is within attack range
            if (!isAttacking)
            {
                // Enemy is not currently attacking, start the attack coroutine
                StartCoroutine(Attack());
            }
        }
        else if (distanceToPlayer <= approachDistance)
        {
            // Enemy is within approach range but outside attack range, move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        }
    }

    private IEnumerator Attack()
    {
        if (canAttack)
        {
            // Set attacking flag to true
            isAttacking = true;

            // Perform attack logic here (e.g., play attack animation, deal damage to player, etc.)
            player.GetComponent<PlayerHealth>().TakeDamage(damage);

            // Disable attack ability for the specified delay
            canAttack = false;
            yield return new WaitForSeconds(attackDelay);
            canAttack = true;

            // Set attacking flag to false
            isAttacking = false;
        }
    }
}
