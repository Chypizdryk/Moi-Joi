using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5f;

    public float MinX = 4f;
    public float MaxX = 8f;
    public float MinY = 4f;
    public float MaxY = 8f;

    public Shooting Fire;
    public float FireRate = 0.2f;
    
    float nextFire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float  h = Input.GetAxis("Horizontal");
       float v = Input.GetAxis("Vertical");
       
       Vector3 movement = new Vector3(h, v, 0).normalized;
       
       transform.position += movement * Speed * Time.deltaTime;
       
       Vector3 pos =  transform.position;
       pos.x = Mathf.Clamp(pos.x, MinX, MaxX);
       pos.y = Mathf.Clamp(pos.y, MinY, MaxY);
       
       transform.position = pos;
       
       if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
       {
           Fire.Shoot();
           nextFire = Time.time + FireRate;
       }
    }
}
