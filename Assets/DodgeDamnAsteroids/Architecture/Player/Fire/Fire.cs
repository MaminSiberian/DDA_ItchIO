using UnityEngine;

namespace Gameplay 
{ 
    public class Fire : MonoBehaviour
    {
        [SerializeField] private int startFireChance;
        [SerializeField] private float fireChanceIncreaseStep;
        [SerializeField] private float fireIncreaseSpeed;
        [SerializeField] private float fireDecreaseByExtinguish;
        [SerializeField] private float extingSpeed;
        [Space]
        [SerializeField] private AudioSource fireSound;
        [SerializeField] private AudioSource extingSound;

        public static bool isOnFire { get; private set; }
        public static float fireLevel { get; private set; }

        private int maxFireValue = 100;
        private Player player;
        private bool isExtinguishing;
        private float newFireLevel;
        private float fireChance;

        private string extingTag = TagStorage.extingTag;
        private string asterTag = TagStorage.asterTag;
        private string causeOfDeath = "You burned out!";

        #region MONOBEHS
        private void Awake()
        {
            player = GetComponent<Player>();
            isOnFire = false;
            fireLevel = 1;
            fireChance = startFireChance;
        }
        private void OnEnable()
        {
            PauseMenu.OnPauseActivatedEvent += Pause;
            PauseMenu.OnPauseDeactivatedEvent += Unpause;
        }
        private void OnDisable()
        {
            PauseMenu.OnPauseActivatedEvent -= Pause;
            PauseMenu.OnPauseDeactivatedEvent -= Unpause;
        }
        private void Update()
        {
            if (fireLevel <= 0)
            {
                fireLevel = 1;
                isOnFire = false;
                isExtinguishing = false;
                StopPlayerFireSound();
            }
            if (fireLevel >= maxFireValue)
            {
                fireLevel = maxFireValue;
                isOnFire = false;
                player.KillPlayer(causeOfDeath);
            }

            if (isExtinguishing)
            {
                Extinguish();
                return;
            }

            if (isOnFire) BurnPlayer();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(extingTag))
                GetExtinguisher();
            
            if (collision.CompareTag(asterTag))
            {
                if (Gameplay.Health.healthValue > 1)
                {
                    if (Random.Range(0, 100) <= fireChance)
                    {
                        PlayPlayerFireSound();
                        isOnFire = true;
                        fireChance = startFireChance;
                    }
                    else
                        fireChance += fireChanceIncreaseStep;
                }
            }
        }
        #endregion

        #region FIRE
        public void BurnPlayer()
        {
            fireLevel += fireIncreaseSpeed * Time.deltaTime;
        }
        private void GetExtinguisher()
        {
            if (isExtinguishing)
                newFireLevel -= fireDecreaseByExtinguish;
            else
                newFireLevel = fireLevel - fireDecreaseByExtinguish;

            if (newFireLevel < 0) newFireLevel = 0;

            isExtinguishing = true;
            if (!extingSound.isPlaying) extingSound.Play();
        }
        private void Extinguish()
        {
            if (fireLevel <= newFireLevel)
            {
                isExtinguishing = false;
                return;
            }

            fireLevel -= extingSpeed * Time.deltaTime;
        }
        #endregion

        #region SOUND
        private void PlayPlayerFireSound()
        {
            if (!fireSound.isPlaying)
                fireSound.Play();
        }
        private void StopPlayerFireSound()
        {
            if (fireSound.isPlaying)
                fireSound.Stop();
        }
        private void Unpause()
        {
            fireSound.UnPause();
        }
        private void Pause()
        {
            fireSound.Pause();
        }
        #endregion
    }
}
