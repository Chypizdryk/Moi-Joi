using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 2f;
    public float resetZ = -10f;
    public float startZ = 10f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < resetZ)
        {
            Vector3 pos = transform.position;
            pos.z = startZ;
            transform.position = pos;
        }
    }
}