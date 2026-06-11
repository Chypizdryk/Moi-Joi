using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemySpeed = 5f;
    public Shooting Fire;
    public float ShootInterval = 1f;

    float nextShootTime;
    
    void Update()
    {
        transform.Translate(Vector3.down * EnemySpeed * Time.deltaTime);
        if (Time.time >= nextShootTime)
        {
            Fire.Shoot();
            nextShootTime = Time.time + ShootInterval;
        }
    }
}
