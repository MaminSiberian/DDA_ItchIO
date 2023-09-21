using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float minTimeBtwSpawn;
    [SerializeField] private float maxTimeBtwSpawn;
    [SerializeField] private int addEnemyStartSpawnChance;
    [SerializeField] private int addSpawnChanceStep;

    private int addEnemySpawnChance;
    private float timeBtwSpawn;
    private float timer = 0f;

    private string UFOTag = TagStorage.UFOTag;

    #region MONOBEHS
    private void OnEnable()
    {
        Player.OnPlayerDeathEvent += OnPlayerDeath;
        SetTimeBtwSpawn();
    }
    private void OnDisable()
    {
        Player.OnPlayerDeathEvent -= OnPlayerDeath;
    }
    private void Update()
    {
        SetSpawnTimer();
    }
    #endregion

    private void SetSpawnTimer()
    {
        if (timer >= timeBtwSpawn)
        {
            SpawnEnemies();
            timer -= timeBtwSpawn;
            SetTimeBtwSpawn();
        }
        else
            timer += Time.deltaTime;
    }
    private void SpawnEnemies()
    {
        SpawnOneEnemy();

        if (Random.Range(0, 100) <= addEnemySpawnChance)
        {
            SpawnOneEnemy();
            addEnemySpawnChance = addEnemyStartSpawnChance;
        }
        else
            addEnemySpawnChance += addSpawnChanceStep;
    }
    private PoolableObject SpawnOneEnemy()
    {
        var obj = PoolManager.GetObject(UFOTag);
        obj.transform.position = this.transform.position;

        return obj;
    }
    private void SetTimeBtwSpawn()
    {
        timeBtwSpawn = Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn);
    }
    private void OnPlayerDeath()
    {
        this.gameObject.SetActive(false);
    }
}
