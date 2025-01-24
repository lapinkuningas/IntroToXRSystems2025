using UnityEngine;

public class OrbitingMovement : MonoBehaviour
{
    public float degreesPerSecond = 15.0f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(0, degreesPerSecond * Time.deltaTime, 0);
    }
}
