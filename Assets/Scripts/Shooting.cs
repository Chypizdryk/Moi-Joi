using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] firePoint;
    public AudioClip shootSound;
   
    public void Shoot()
    {
        foreach (Transform fp in firePoint)
        {
            Instantiate(bullet, fp.position, fp.rotation);

            AudioManager.instance.Play(shootSound);
        }
    }
}