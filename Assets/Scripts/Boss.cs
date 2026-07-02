using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Timings")]
    public float enterTime = 2f;
    public float waitTime = 1f;
    public float enterSpeed = 2f;

    [Header("Shooting")]
    public Shooting fire;
    public Shooting fire2;
    public float shootInterval = 1.5f;

    [Header("Health")]
    public int maxHP = 2;
    int currentHP;
    
    [Header("Sin Movement")]
    public float frequency = 1.6f;
    public float amplitude = 4f; 

    MeshRenderer rend;
    Material[] mats;

    float timer;
    float stateTimer;
    float nextShoot;
    
    bool invincible = true;
    
    int state = 0;
    int phase = 1;
    
    float startX;
    float sinTimer;
    
    void Start()
    {
        currentHP = maxHP;
        startX = transform.position.x;
        
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
            
            sinTimer += Time.deltaTime;

            Vector3 pos = transform.position;
            
            pos.x = startX + Mathf.Sin(sinTimer * frequency) * amplitude;

            transform.position = pos;
            
            if (Time.time >= nextShoot)
            {
                if (phase < 3)
                fire.Shoot();

                if (phase == 3)
                    fire2.Shoot();

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

        if (phase == 1 && currentHP <= maxHP * 2 / 3)
        {
            phase = 2;
            shootInterval = 0.4f;
            amplitude = 7f;
        }

        if (phase == 2 && currentHP <= maxHP / 3)
        {
            phase = 3;
            shootInterval  = 0.8f;
            amplitude = 9f;
            frequency = 1.8f;
        }
        
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
        ScoreText.Instance.AddScore(250);
        Destroy(gameObject);
    }
}
