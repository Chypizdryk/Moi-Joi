using UnityEngine;

public class Background : MonoBehaviour
{
    public float BackSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * BackSpeed * Time.deltaTime);
        if (transform.position.y < -5f)
            transform.position = new Vector3(0, 20, 0);
    }
}
