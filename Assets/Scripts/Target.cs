using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector3 Velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Velocity * Time.deltaTime;
    }
}
