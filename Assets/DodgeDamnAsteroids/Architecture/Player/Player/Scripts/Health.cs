using UnityEngine;
using DG.Tweening;

namespace Gameplay
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _startHealthValue = 3;
        [SerializeField] private int _maxHealthValue = 6;
        [Space]
        [SerializeField] private float invincibilityTime;
        [Space]
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private float blinkRate;
        
        public static int startHealthValue { get; private set; }
        public static int maxHealthValue { get; private set; }
        public static int healthValue { get; private set; }
        public static bool isInvincible { get; private set; }

        private Player player;

        #region BLINK_PARAMS
        private Tween tween;
        private float reducedAlpha;
        private float normalAlpha;
        private float alphaCoeff = 0.25f;
        private float timer = 0f;
        #endregion

        #region STRING_PARAMS
        private string heartTag = TagStorage.heartTag;
        private string asterTag = TagStorage.asterTag;
        private string projectileTag = TagStorage.UFOProjectileTag;
        private string causeOfDeath;
        private string killedByAsteroid = "You crashed into asteroid!";
        private string killedByUFO = "You were shot by UFO!";
        #endregion

        #region MONOBEHS
        private void Awake()
        {
            player = GetComponent<Player>();
            isInvincible = false;

            normalAlpha = sprite.color.a;
            reducedAlpha = normalAlpha * alphaCoeff;

            startHealthValue = _startHealthValue;
            maxHealthValue = _maxHealthValue;
            healthValue = startHealthValue;
        }
        private void OnDisable()
        {
            tween.Kill();
        }
        private void Update()
        {
            if (isInvincible)
            {
                Blink();
                SetInvincibilityTimer();
            }
            else
                ReturnToNormalAlpha();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(heartTag))
            {
                SoundsManager.PlayGetHeartSound();
                IncreaseHealth();
            }
            
            if (collision.CompareTag(asterTag))
            {
                causeOfDeath = killedByAsteroid;
                DecreaseHealth();
            }

            if (collision.CompareTag(projectileTag))
            {
                causeOfDeath = killedByUFO;
                SoundsManager.PlayHitSound();
                DecreaseHealth();
            }
        }
        #endregion

        #region HEALTH
        public void IncreaseHealth()
        {
            if (healthValue < maxHealthValue)
            healthValue++;
        }
        public void DecreaseHealth()
        {
            if (isInvincible) return;

            if (healthValue > 0)
            {
                healthValue--;
                isInvincible = true;
            }
            else
                return;

            if (healthValue <= 0)
                player.KillPlayer(causeOfDeath);

            CameraShaker.ShakeCamera();
        }
        #endregion

        #region INVICIBILITY
        private void Blink()
        {
            if (sprite.color.a == normalAlpha)
                tween = sprite.DOFade(reducedAlpha, blinkRate);

            if (sprite.color.a == reducedAlpha)
                tween = sprite.DOFade(normalAlpha, blinkRate);
        }
        private void SetInvincibilityTimer()
        {
            if (timer >= invincibilityTime)
            {
                isInvincible = false;
                tween.Kill();
                timer -= invincibilityTime;
            }
            else
                timer += Time.deltaTime;
        }
        private void ReturnToNormalAlpha()
        {
            Color color = sprite.color;
            color.a = normalAlpha;
            sprite.color = color;
        }
        #endregion
    }
}
