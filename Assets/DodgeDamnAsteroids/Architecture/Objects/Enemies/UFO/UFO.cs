using System.Collections.Generic;
using UnityEngine;

public class UFO : PoolableObject
{
    [SerializeField] private int startHealth = 3;
    [Space]
    [SerializeField] private float projectileForce;
    [SerializeField] private float minReloadTime;
    [SerializeField] private float maxReloadTime;
    [Space]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minYpos = 1.5f;
    [SerializeField] private float maxYpos = 4;
    [SerializeField] private float maxXpos = 1.5f;
    [Space]
    [SerializeField] private float blinkTime;
    [SerializeField] private float blinkRate;
    [Space]
    [SerializeField] private List<AudioSource> shootSounds;
    private static float minPitch = 0.92f;
    private static float maxPitch = 1.08f;

    private int health;
    private float distance = 0.1f;
    // tags
    private string projectileTag = TagStorage.UFOProjectileTag;
    private string bombTag = TagStorage.bombTag;
    // shooting
    private Player player;
    private Vector3 targetPos;
    private int forceMultiplier = 50;
    private int speedMultiplier = 10;
    // reloading
    private bool isLoaded = false;
    private float reloadTimer = 0f;
    private float reloadTime;
    // blinking
    private bool isBlinking;
    private SpriteRenderer sprite;
    private float blinkTimeTimer = 0f;
    private float blinkRateTimer = 0f;

    #region MONOBEHS
    private void OnEnable()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = true;

        player = FindAnyObjectByType<Player>();

        health = startHealth;
        SetReloadTime();
        SetTargetPos();
    }
    protected override void Update()
    {
        base.Update();
        if (player == null) return;

        if (isLoaded)
        {
            Shoot();
            isLoaded = false;
        }
        else
            Reload();

        Move();

        if (isBlinking)
        {
            SetBlinkTimer();
            Blink();
        }
        else
            sprite.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(bombTag))
            GetDamage();
    }
    #endregion

    #region MOVEMENT
    private void Move()
    {
        if (Vector3.Distance(this.transform.position, targetPos) <= distance) SetTargetPos();

        this.transform.position = 
            Vector3.MoveTowards(this.transform.position, targetPos, moveSpeed / speedMultiplier * Time.deltaTime);
    }
    private void SetTargetPos()
    {
        targetPos = new Vector3(Random.Range(-maxXpos, maxXpos), Random.Range(minYpos, maxYpos), 0f);
    }
    #endregion

    #region SHOOTING
    private UFOProjectile Shoot()
    {
        var obj = PoolManager.GetObject(projectileTag);
        obj.transform.position = this.transform.position;
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        obj.GetComponent<Rigidbody2D>().AddForce(direction * projectileForce * forceMultiplier);

        PlayShootSound();

        return (UFOProjectile)obj;
    }
    private void PlayShootSound()
    {
        AudioSource audioSource = shootSounds[Random.Range(0, shootSounds.Count)];
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play();
    }
    #endregion

    #region RELOADING
    private void Reload()
    {
        if (reloadTimer >= reloadTime)
        {
            isLoaded = true;
            reloadTimer -= reloadTime;
            SetReloadTime();
        }
        else
            reloadTimer += Time.deltaTime;
    }
    private void SetReloadTime()
    {
        reloadTime = Random.Range(minReloadTime, maxReloadTime);
    }
    #endregion

    #region DAMAGE
    private void GetDamage()
    {
        health--;

        if (health >= 1)
        {
            blinkTimeTimer = 0;
            isBlinking = true;
        }
        else
            KillUFO();
    }
    private void KillUFO()
    {
        isBlinking = false;
        this.gameObject.SetActive(false);
    }
    private void SetBlinkTimer()
    {
        if (blinkTimeTimer >= blinkTime)
        {
            isBlinking = false;
            blinkTimeTimer -= blinkTime;
        }
        else
            blinkTimeTimer += Time.deltaTime;
    }
    private void Blink()
    {
        if (blinkRateTimer >= blinkRate)
        {
            sprite.enabled = !sprite.enabled;
            blinkRateTimer -= blinkRate;
        }
        else
            blinkRateTimer += Time.deltaTime;
    }
    #endregion
}
