using UnityEngine;

public class Explosion : PoolableObject
{
    private AudioSource explosionSound;
    private static float minPitch = 0.92f;
    private static float maxPitch = 1.08f;

    private SpriteRenderer sprite;

    private void Awake()
    {
        explosionSound = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        sprite.enabled = true;

        explosionSound.pitch = Random.Range(minPitch, maxPitch);
        explosionSound.Play();
    }
    protected override void Update()
    {
        base.Update();

        if (!explosionSound.isPlaying)
            this.gameObject.SetActive(false);
    }
    public void TurnOffSprite()
    {
        sprite.enabled = false;
    }
}
