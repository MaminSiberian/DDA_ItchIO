using UnityEngine;
using DG.Tweening;

public class UFOProjectile : PoolableObject
{
    private string playerTag = TagStorage.playerTag;

    private SpriteRenderer sprite;
    private Tween tween;
    private float reducedAlpha;
    private float normalAlpha;
    private float alphaCoeff = 0.25f;
    private float speed = 0.8f;

    private void Awake()
    {
        this.gameObject.AddComponent<ObstacleCollisionHandler>();
        sprite = GetComponent<SpriteRenderer>();

        normalAlpha = sprite.color.a;
        reducedAlpha = normalAlpha * alphaCoeff;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        tween.Kill();
    }
    protected override void Update()
    {
        base.Update();

        Blink();
    }
    private void Blink()
    {
        if (sprite.color.a == normalAlpha)
            tween =  sprite.DOFade(reducedAlpha, speed);

        if (sprite.color.a == reducedAlpha)
            tween = sprite.DOFade(normalAlpha, speed);
    }
}
