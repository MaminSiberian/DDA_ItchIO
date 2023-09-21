using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDeathEvent;
    public static string causeOfDeath { get; private set; }

    private string exploionTag = TagStorage.explosionTag;

    private void Start()
    {
        this.gameObject.SetActive(true);
    }
    public void KillPlayer(string _causeOfDeath)
    {
        causeOfDeath = _causeOfDeath;

        var obj = PoolManager.GetObject(exploionTag);
        obj.transform.position = this.transform.position;

        OnPlayerDeath();
        this.gameObject.SetActive(false);
    }
    private void OnPlayerDeath()
    {
        OnPlayerDeathEvent?.Invoke();
    }
}
