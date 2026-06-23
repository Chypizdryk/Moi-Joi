using UnityEngine;

public class FastEnemy : MonoBehaviour
{
    public float EnemySpeed = 6f;
    public Shooting Fire;
    public float ShootInterval = 1f;

    float nextShootTime;
    
    void Update()
    {
        transform.Translate(Vector3.back * EnemySpeed * Time.deltaTime);
        
        if (Time.time >= nextShootTime)
        {
            Fire.Shoot();
            nextShootTime = Time.time + ShootInterval;
        }
    }
}
