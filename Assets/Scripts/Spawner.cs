using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject FastEnemy;
    public GameObject SinEnemy;
    public GameObject Boss;
    public Slider BossHP;
    public Transform spawnerL;
    public Transform spawnerM;
    public Transform spawnerR;

    private bool wave1Spawned;
    private bool wave2Spawned;
    private bool wave3Spawned;
    private bool wave4Spawned;
    private bool wave5Spawned;
    private bool wave6Spawned;
    private bool wave7Spawned;
    private bool wave8Spawned;
    private bool wave9Spawned;
    private bool bossSpawned;
    
    float time = 0f;
    
    void Update()
    {
        time += Time.deltaTime;
        
        if (time >= 4.5f && !wave1Spawned)
        {
            SpawnWave1();
            wave1Spawned = true;
        }

        if (time >= 20f && !wave2Spawned)
        {
            StartCoroutine(SpawnWave2());
            wave2Spawned = true;
        }

        if (time >= 39f && !wave3Spawned)
        {
            SpawnWave3();
            wave3Spawned = true;
        }

        if (time >= 48f && !wave4Spawned)
        {
            SpawnWave4();
            wave4Spawned = true;
        }
        
        if (time >= 61f && !wave5Spawned)
        {
            SpawnWave5();
            wave5Spawned = true;
        }
        
        if (time >= 74f && !wave6Spawned)
        {
            SpawnWave6();
            wave6Spawned = true;
        }
        
        if (time >= 87f && !wave7Spawned)
        {
            SpawnWave7();
            wave7Spawned = true;
        }
        
        if (time >= 100f && !wave8Spawned)
        {
            SpawnWave8();
            wave8Spawned = true;
        }

        if (time >= 113f && !bossSpawned)
        {
            SpawnBoss();
            bossSpawned = true;
        }
    }

    private void SpawnWave1()
    {
        Instantiate(Enemy, spawnerL.position, Quaternion.identity);
        Instantiate(Enemy, spawnerR.position, Quaternion.identity);
    }
    
    private IEnumerator SpawnWave2()
    {
        Instantiate(Enemy, spawnerL.position, Quaternion.identity);
        Instantiate(Enemy, spawnerR.position, Quaternion.identity);
        
        yield return new WaitForSeconds(3.5f);
        
        Instantiate(Enemy, spawnerL.position, Quaternion.identity);
        Instantiate(Enemy, spawnerM.position, Quaternion.identity); 
        Instantiate(Enemy, spawnerR.position, Quaternion.identity);  
    }

    private void SpawnWave3()
    {
        Instantiate(Enemy, spawnerL.position, Quaternion.identity);
        Instantiate(FastEnemy, spawnerM.position, Quaternion.identity);
        Instantiate(Enemy, spawnerR.position, Quaternion.identity);
    } 
    
    private void SpawnWave4() 
    {
        Instantiate(Enemy, spawnerL.position, Quaternion.identity);
        Instantiate(Enemy, spawnerM.position, Quaternion.identity);
        Instantiate(Enemy, spawnerR.position, Quaternion.identity);
    }

    private void SpawnWave5()
    {
        Instantiate(FastEnemy, spawnerL.position, Quaternion.identity);
        Instantiate(FastEnemy, spawnerR.position, Quaternion.identity);
    }

    private void SpawnWave6() 
    {
        Instantiate(Enemy, spawnerL.position, Quaternion.identity);
        Instantiate(SinEnemy, spawnerM.position, Quaternion.identity);
        Instantiate(Enemy, spawnerR.position, Quaternion.identity);
    }
    
    private void SpawnWave7() 
    {
        Instantiate(SinEnemy, spawnerL.position, Quaternion.identity);
        Instantiate(SinEnemy, spawnerR.position, Quaternion.identity);
    }
    
    private void SpawnWave8() 
    {
        Instantiate(SinEnemy, spawnerL.position, Quaternion.identity);
        Instantiate(SinEnemy, spawnerM.position, Quaternion.identity);
        Instantiate(SinEnemy, spawnerR.position, Quaternion.identity);
    }
    
    private void SpawnBoss()
    {
        GameObject boss = Instantiate(Boss, spawnerM.position, Quaternion.identity);
        
        Boss bossScript = boss.GetComponent<Boss>();
        
        bossScript.healthBar = BossHP;
        bossScript.SetHP();
        
        BossHP.gameObject.SetActive(true);
    }
}
