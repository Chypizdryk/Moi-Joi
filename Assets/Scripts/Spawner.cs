using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    
    public float SpawnRate = 1.5f;
    float nextSpawn;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            SpawnEnemy();
            nextSpawn = Time.time + SpawnRate;
        }
    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(-6f, 6f);
        Vector3 spawnPos = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);
        Instantiate(Enemy,  spawnPos, Quaternion.identity);
    }
}
