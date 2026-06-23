using UnityEngine;

public class SinEnemy : MonoBehaviour
{
    public float EnemySpeed = 4f;
    public float Frequency = 10f;
    public float Amplitude = 1f;
    
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }
    
    void Update()
    {   
        Vector3 pos = transform.position;
        
        pos.z -= EnemySpeed * Time.deltaTime;
        pos.x = startX + Mathf.Sin(Time.time * Frequency) * Amplitude;
        
        transform.position = pos;
    }
}
