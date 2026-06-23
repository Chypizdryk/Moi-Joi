using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform[] FirePoint;
   
    public void Shoot()
    {
        foreach (Transform fp in FirePoint)
        {
            Instantiate(Bullet, fp.position, fp.rotation);
        }
    }
}