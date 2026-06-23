using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject FastEnemy;
    public GameObject SinEnemy;
    public GameObject Boss;
    public Transform spawnerL;
    public Transform spawnerM;
    public Transform spawnerR;

    private bool wave1Spawned;
    private bool wave2Spawned;
    private bool wave3Spawned;
    private bool wave4Spawned;
    private bool bossSpawned;
    
    void Update()
    {
        float time = Time.time;
        
        if (time >= 0f && !wave1Spawned)
        {
            SpawnWave1();
            wave1Spawned = true;
        }

        if (time >= 10f && !wave2Spawned)
        {
            SpawnWave2();
            wave2Spawned = true;
        }

        if (time >= 25f && !wave3Spawned)
        {
            SpawnWave3();
            wave3Spawned = true;
        }

        if (time >= 40f && !wave4Spawned)
        {
            SpawnWave4();
            wave4Spawned = true;
        }

        if (time >= 60f && !bossSpawned)
        {
            SpawnBoss();
            bossSpawned = true;
        }
    }

    private void SpawnWave1()
    {
        Instantiate(Enemy, spawnerL.position, Quaternion.identity);
        Instantiate(Enemy, spawnerM.position, Quaternion.identity);
        Instantiate(Enemy, spawnerR.position, Quaternion.identity);
    }
    
    private void SpawnWave2()
    {
        Instantiate(Enemy, spawnerL.position, Quaternion.identity);
        Instantiate(Enemy, spawnerM.position, Quaternion.identity);
        Instantiate(Enemy, spawnerR.position, Quaternion.identity);
        Instantiate(Enemy,  spawnerL.position + Vector3.right * 2, Quaternion.identity);
        Instantiate(Enemy,  spawnerL.position + Vector3.left * 2, Quaternion.identity);
    }

    private void SpawnWave3()
    {
        Instantiate(FastEnemy, spawnerL.position, Quaternion.identity);
        Instantiate(FastEnemy, spawnerR.position, Quaternion.identity);
    } 
    
    private void SpawnWave4() 
    {
        Instantiate(SinEnemy, spawnerL.position, Quaternion.identity);
        Instantiate(SinEnemy, spawnerM.position, Quaternion.identity);
        Instantiate(SinEnemy, spawnerR.position, Quaternion.identity);
    }
    
    private void SpawnBoss()
    {
        Instantiate(Boss, spawnerM.position, Quaternion.identity);
    }
}
