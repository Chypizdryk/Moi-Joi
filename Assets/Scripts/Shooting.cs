using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;
   
    public void Shoot()
    {
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
}