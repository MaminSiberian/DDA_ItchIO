using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float timeBtwSpawn;
    [SerializeField] private List<Transform> _spawnPositions = new List<Transform>(4);
    [Header("Asteroids")]
    [SerializeField] private int asterStartSpawnChance;
    [SerializeField] private float asterSpawnIncreaseStep;
    [Header("Extinguishers")]
    [SerializeField] private int extingStartSpawnChance;
    [SerializeField] private float extingSpawnIncreaseStep;
    [Header("Fuel")]
    [SerializeField] private int canisterStartSpawnChance;
    [SerializeField] private float canisterSpawnIncreaseStep;
    [Header("Hearts")]
    [SerializeField] private int heartStartSpawnChance;
    [SerializeField] private float heartSpawnIncreaseStep;

    public static List<Transform> spawnPositions { get; private set; }

    private float asterSpawnChance; 
    private float canisterSpawnChance;
    private float extingSpawnChance;
    private float heartSpawnChance;

    private float timer = 0f;
    private int maxSpawnChance = 90;

    #region STRING_PARAMS
    private string asterTag = TagStorage.asterTag;
    private string canisterTag = TagStorage.canisterTag;
    private string extingTag = TagStorage.extingTag;
    private string heartTag = TagStorage.heartTag;
    #endregion

    #region MONOBEHS
    private void Awake()
    {
        spawnPositions = _spawnPositions;

        asterSpawnChance = asterStartSpawnChance;
        canisterSpawnChance = canisterStartSpawnChance;
        extingSpawnChance = extingStartSpawnChance;
        heartSpawnChance = heartStartSpawnChance;
    }
    private void Update()
    {
        SetSpawnTimer();
    }
    #endregion

    #region GENERAL_SPAWN_LOGIC
    private void SetSpawnTimer()
    {
        if (timer >= timeBtwSpawn)
        {
            SpawnRandomObjects();
            timer -= timeBtwSpawn;
        }
        else
            timer += Time.deltaTime;
    }
    private void SpawnRandomObjects()
    {
        if (Gameplay.Fire.isOnFire && Random.Range(0, 100) <= extingSpawnChance)
        {
            SpawnExting();
            return;
        }
        if (Random.Range(0, 100) <= canisterSpawnChance)
        {
            SpawnCanister();
            return;
        }
        if (Random.Range(0, 100) <= heartSpawnChance && Gameplay.Health.healthValue < Gameplay.Health.maxHealthValue)
        {
            SpawnHeart();
            return;
        }
        if (Random.Range(0, 100) <= asterSpawnChance)
        {
            SpawnAsteroids();
            return;
        }
    }
    private PoolableObject SpawnObject(string tag, Transform pos)
    {
        var obj = PoolManager.GetObject(tag);
        obj.transform.position = pos.position;

        return obj;
    }
    private List<Transform> GetRandomPositions(int numberOfPositions = 1)
    {
        System.Random random = new System.Random();
        List<Transform> positions = spawnPositions.OrderBy(x => random.Next()).Take(numberOfPositions).ToList();
        return positions;
    }
    private void IncreaseSpawnChances()
    {
        if (asterSpawnChance <= maxSpawnChance) asterSpawnChance += asterSpawnIncreaseStep;

        if (canisterSpawnChance <= maxSpawnChance) canisterSpawnChance += canisterSpawnIncreaseStep;

        if (extingSpawnChance <= maxSpawnChance && Gameplay.Fire.isOnFire) 
            extingSpawnChance += extingSpawnIncreaseStep;
        if (heartSpawnChance <= maxSpawnChance) 
            heartSpawnChance += heartSpawnIncreaseStep;
    }
    #endregion

    #region SPAWN_METHODS_FOR_OBJECTS
    private void SpawnAsteroids()
    {
        GetRandomPositions(Random.Range(0, 4)).ForEach(p => SpawnObject(asterTag, p));
        IncreaseSpawnChances();
        asterSpawnChance = asterStartSpawnChance;
    }
    private void SpawnExting()
    {
        GetRandomPositions(1).ForEach(p => SpawnObject(extingTag, p));
        IncreaseSpawnChances();
        extingSpawnChance = extingStartSpawnChance;
    }
    private void SpawnCanister()
    {
        GetRandomPositions(1).ForEach(p => SpawnObject(canisterTag, p));
        IncreaseSpawnChances();
        canisterSpawnChance = canisterStartSpawnChance;
    }
    private void SpawnHeart()
    {
        GetRandomPositions(1).ForEach(p => SpawnObject(heartTag, p));
        IncreaseSpawnChances();
        heartSpawnChance = heartStartSpawnChance;
    }
    #endregion
}
