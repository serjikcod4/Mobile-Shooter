using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб монстра
    public int numberOfEnemies = 3; // Количество монстров, которые нужно создать
    public float spawnRadius = 10f; // Радиус, в котором монстры будут создаваться

    private void Start()
    {
        // Создаем заданное количество монстров
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Генерируем случайные координаты внутри заданного радиуса
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Создаем монстра в сгенерированной позиции
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
