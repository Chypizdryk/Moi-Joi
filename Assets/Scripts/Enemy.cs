using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float enterSpeed = 2f;
    public float moveSpeed = 5f;

    [Header("Timings")]
    public float enterTime = 2f;
    public float waitTime = 1f;

    [Header("Shooting")]
    public Shooting fire;
    public float shootInterval = 1f;

    float timer;
    float stateTimer;
    float nextShoot;

    int state = 0; 
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (state == 0)
        {
            transform.Translate(Vector3.back * enterSpeed * Time.deltaTime);

            if (timer >= enterTime)
            {
                state = 1;
                stateTimer = 0f;
            }

            return;
        }
        
        if (state == 1)
        {
            stateTimer += Time.deltaTime;

            if (stateTimer >= waitTime)
            {
                state = 2;
            }

            return;
        }
        
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        if (Time.time >= nextShoot)
        {
            if (fire != null)
                fire.Shoot();

            nextShoot = Time.time + shootInterval;
        }
    }
}