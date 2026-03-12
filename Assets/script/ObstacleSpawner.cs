using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("=== Obstacle Settings ===")]
    public GameObject[] obstaclePrefabs;      // ← drag your prefabs here
    public float minSpawnDelay = 1.5f;        // shortest time between spawns
    public float maxSpawnDelay = 3.0f;        // longest time between spawns

    [Header("=== Spawn Position ===")]
    public float spawnX = 12f;                // how far right to spawn (off-screen)
    public float minY = -3f;                  // lowest possible Y position
    public float maxY = 3f;                   // highest possible Y position

    void Start()
    {
        // Start spawning immediately
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        // Pick random obstacle from array
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject chosenObstacle = obstaclePrefabs[randomIndex];

        // Pick random height
        float randomY = Random.Range(minY, maxY);

        // Create spawn position
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);

        // Actually create (spawn) the obstacle
        Instantiate(chosenObstacle, spawnPosition, Quaternion.identity);

        // Schedule next spawn after random delay
        float nextDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        Invoke("SpawnObstacle", nextDelay);
    }
}