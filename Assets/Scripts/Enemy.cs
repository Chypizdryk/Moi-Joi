using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float enterSpeed = 2f;
    public float moveSpeed = 1.5f;

    [Header("Timings")]
    public float enterTime = 2f;
    public float waitTime = 1f;


    [Header("Shooting")]
    public Shooting fire;
    public float shootInterval = 1.5f;

    [Header("Health")]
    public int maxHP = 3;
    int currentHP;

    MeshRenderer rend;
    Material[] mats;

    float timer;
    float stateTimer;
    float nextShoot;
    
    bool invincible = true;
    
    int state = 0;

    void Start()
    {
        currentHP = maxHP;
        
        rend = GetComponentInChildren<MeshRenderer>();
        mats = rend.materials;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (state == 0)
        {
            invincible = true;
            
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
            invincible = true;
            
            stateTimer += Time.deltaTime;

            if (stateTimer >= waitTime)
            {
                state = 2;
            }

            return;
        }

        if (state == 2)
        {
            invincible = false;
            
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

            if (Time.time >= nextShoot)
            {
                if (fire != null)
                    fire.Shoot();

                nextShoot = Time.time + shootInterval;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (state == 2)
        StartCoroutine(HitDamage());
        
        if (invincible)
        {
            return;
        }
        
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    IEnumerator HitDamage()
    {
        foreach (Material mat in mats)
        {
            if (mat.HasProperty("_EmissionColor"))
            {
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", Color.red * 1f);
            }
        }
        
        yield return  new WaitForSeconds(0.1f);

        foreach (Material mat in mats)
        {
            if (mat.HasProperty("_EmissionColor"))
                mat.SetColor("_EmissionColor", Color.black);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}