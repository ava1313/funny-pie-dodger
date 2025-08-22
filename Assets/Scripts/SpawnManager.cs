using UnityEngine;

/// <summary>
/// Spawns obstacles at a regular interval.
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 1.5f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float xPos = Random.Range(-8f, 8f);
        Vector3 spawnPos = new Vector3(xPos, 6f, 0f);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
