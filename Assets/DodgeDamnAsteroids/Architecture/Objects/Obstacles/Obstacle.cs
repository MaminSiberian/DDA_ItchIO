using UnityEngine;

public class Obstacle : PoolableObject
{
    [SerializeField] protected float minRotationSpeed;
    [SerializeField] protected float maxRotationSpeed;
    protected Rotator rotator;

    protected void Awake()
    {
        this.gameObject.AddComponent<ObstacleCollisionHandler>();
        this.gameObject.AddComponent<ObstacleMover>();
        rotator = this.gameObject.AddComponent<Rotator>();
    }
    protected void OnEnable()
    {
        rotator.Init(minRotationSpeed, maxRotationSpeed);
    }
}
