using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float rotationSpeed;
    private int speedMultiplier = 50;

    public void Init(float minSpeed, float maxSpeed)
    {
        rotationSpeed = Random.Range(minSpeed, maxSpeed);
        if (Random.Range(0, 2) == 1) rotationSpeed *= -1;
    }
    private void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * speedMultiplier * Time.deltaTime);
    }
}
