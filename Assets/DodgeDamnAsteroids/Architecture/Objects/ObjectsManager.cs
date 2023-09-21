using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    [SerializeField] private float _obstaclesSpeed;
    public static float obstaclesSpeed { get; private set; }

    private void Awake()
    {
        obstaclesSpeed = _obstaclesSpeed;
    }
}
