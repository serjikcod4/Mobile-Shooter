using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage = 10;

    
    private Transform bulletSpawnPos;
    private Transform targetTransform;
    private Vector3 targetPos;

    private void Start() {
        StartCoroutine(SelfDestroy());
    }

    private void Update() {
        BulletMovement();
        DestroyBullet();
    }

    public void BulletMovement() {

        // Calculate the direction from bullet position to the target position
        Vector3 direction = targetPos - transform.position;

        // Normalize the direction vector
        direction.Normalize();

        // Rotate the bullet to face the target position
        transform.localRotation = Quaternion.LookRotation(direction);

        // Move the bullet towards the target
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetTarget(Transform target)
    {
        targetTransform = target;
        targetPos = targetTransform.position;
    }


    public void DestroyBullet()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetPos);

        if (distanceToTarget <= 0.1f && targetTransform != null)
        {
            targetTransform.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log("Enemy Hitted");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log("Enemy Hitted");
        }
    }

    public IEnumerator SelfDestroy() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
