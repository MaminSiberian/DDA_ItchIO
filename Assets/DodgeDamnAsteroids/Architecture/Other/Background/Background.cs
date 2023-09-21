using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float speed;
    [SerializeField] private float height;

    private List<GameObject> prefabs = new List<GameObject>();
    private int numberOfPrefabs = 3;
    private float minY;
    private float maxY;

    private void Awake()
    {
        minY = -height;
        
        CreateBackground();
    }
    private void OnEnable()
    {
        Player.OnPlayerDeathEvent += TurnOff;
    }
    private void OnDisable()
    {
        Player.OnPlayerDeathEvent -= TurnOff;
    }
    private void Update()
    {
        prefabs.ForEach(p => Move(p.transform));
    }
    private void CreateBackground()
    {
        float y = 0;

        for (int i = 0; i < numberOfPrefabs; i++)
        {
            var obj = Instantiate(prefab);
            obj.transform.SetParent(this.transform);
            obj.transform.position = new Vector3(transform.position.x, y, transform.position.z);

            prefabs.Add(obj);
            y += height;
        }

        maxY = prefabs.Last().transform.position.y;
    }
    private void Move(Transform obj)
    {
        if (obj.position.y <= minY)
            obj.position = new Vector3(obj.position.x, maxY, obj.position.z);

        obj.position += Vector3.down * speed * Time.deltaTime;
    }
    private void TurnOff()
    {
        this.enabled = false;
    }
}
