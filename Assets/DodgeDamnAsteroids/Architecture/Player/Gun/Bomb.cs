using UnityEngine;

public class Bomb : PoolableObject
{
    [SerializeField] private float minRotationSpeed;
    [SerializeField] private float maxRotationSpeed;

    private string asterTag = TagStorage.asterTag;
    private string UFOTag = TagStorage.UFOTag;
    private string explosionTag = TagStorage.explosionTag;
    private Rotator rotator;

    private void Awake()
    {
        rotator = this.gameObject.AddComponent<Rotator>();
    }
    private void OnEnable()
    {
        rotator.Init(minRotationSpeed, maxRotationSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(asterTag) || collision.CompareTag(UFOTag))
        {
            BlowUp(collision.transform.position);
        }
    }
    private void BlowUp(Vector3 pos)
    {
        var obj = PoolManager.GetObject(explosionTag);
        obj.transform.position = pos;

        this.gameObject.SetActive(false);
    }
}
