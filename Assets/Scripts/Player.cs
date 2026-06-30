using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHP = 10;
    int currentHP;
    bool isDead = false;
    
    MeshRenderer rend;
    Material[] mats;

    public float Speed = 5f;

    public float MinX = -4f;
    public float MaxX = 4f;

    public float MinZ = -4f;
    public float MaxZ = 4f;

    public Shooting Fire;
    public float FireRate = 0.2f;

    private float nextFire;

    void Start()
    {
        currentHP = maxHP;
        
        rend = GetComponentInChildren<MeshRenderer>();
        mats = rend.materials;
    }

    void Update()
    {
        if (isDead)
        {
            transform.Translate(Vector3.down * 2f * Time.deltaTime);
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0f, v).normalized;

        transform.position += movement * Speed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, MinX, MaxX);
        pos.z = Mathf.Clamp(pos.z, MinZ, MaxZ);
        transform.position = pos;

        float targetTilt = -h * 10f;

        Quaternion targetRotation =
            Quaternion.Euler(0f, 0f, targetTilt);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            10f * Time.deltaTime
        );

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFire)
        {
            Fire.Shoot();
            nextFire = Time.time + FireRate;
        }
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(HitDamage());
        
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
        isDead = true;

        Time.timeScale = 0.2f;

        Fire.enabled = false;

        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);

            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
        }

        if (other.CompareTag("FastEnemy"))
        {
            TakeDamage(1);

            FastEnemy fastenemy = other.GetComponent<FastEnemy>();

            if (fastenemy != null)
            {
                fastenemy.TakeDamage(1);
            }
        }

        if (other.CompareTag("SinEnemy"))
        {
            TakeDamage(1);

            SinEnemy sinenemy = other.GetComponent<SinEnemy>();

            if (sinenemy != null)
            {
                sinenemy.TakeDamage(1);
            }

            if (other.CompareTag("Boss"))
            {
                TakeDamage(1);

                Boss boss = other.GetComponent<Boss>();

                if (boss != null)
                {
                    boss.TakeDamage(1);
                }
            }
        }
    }
}
