using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 10f;
    
    void Update()
    {
        transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }
}
