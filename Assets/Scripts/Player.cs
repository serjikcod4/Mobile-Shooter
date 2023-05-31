using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerFire playerFire;
    private float currentDistanceToPlayer;
    private GameObject currentTarget;

    public bool playerIsDead = false;
    public float shootingDistance = 5f; // Дистанция, с которой игрок может стрелять
    public float shootingRadius = 2f; // Радиус области для стрельбы
    public float shootingAngle = 45f; // Угол конуса стрельбы
    public LayerMask enemyLayer; // Маска слоя противников
    public KeyCode shootKey = KeyCode.Space; // Клавиша для стрельбы

    private void Start() {
        playerFire = gameObject.GetComponent<PlayerFire>();
    }

    private void Update()
    {
        
    }

    public void Shoot()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, shootingRadius, enemyLayer);

        float minDistance = Mathf.Infinity;
        currentTarget = null;

        foreach (Collider2D enemyCollider in enemies)
        {
            Vector2 direction = (enemyCollider.transform.position - transform.position).normalized;
            float angle = Vector2.Angle(transform.right, direction);

            if (angle <= shootingAngle * 0.5f)
            {
                float distance = Vector2.Distance(transform.position, enemyCollider.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    currentTarget = enemyCollider.gameObject;
                }
            }
        }

        if (currentTarget != null && !playerIsDead)
        {
            playerFire.Fire(currentTarget.transform);
        }
    }


    public void Death() {
        playerIsDead = true;
    }
}
