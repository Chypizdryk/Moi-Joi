using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (CompareTag("PlayerBullet"))
        {
            if (other.CompareTag("Enemy"))
            {
                Enemy enemy = other.GetComponentInParent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                Destroy(gameObject);
            }

            if (other.CompareTag("FastEnemy"))
            {
                FastEnemy fastenemy = other.GetComponentInParent<FastEnemy>();

                if (fastenemy != null)
                {
                    fastenemy.TakeDamage(damage);
                }

                Destroy(gameObject);
            }

            if (other.CompareTag("Player"))
            {
                return;
            }
        }

        if (CompareTag("EnemyBullet"))
        {
            if (other.CompareTag("Player"))
            {
                Player player = other.GetComponentInParent<Player>();

                if (player != null)
                {
                    player.TakeDamage(damage);
                }

                Destroy(gameObject);
            }

            if (other.CompareTag("Enemy"))
            {
                return;
            }
        }
    }
}