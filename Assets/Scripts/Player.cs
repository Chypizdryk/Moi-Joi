using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5f;

    public float MinX = -4f;
    public float MaxX = 4f;

    public float MinZ = -4f;
    public float MaxZ = 4f;

    public Shooting Fire;
    public float FireRate = 0.2f;

    private float nextFire;

    void Update()
    {
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
}