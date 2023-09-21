using NaughtyAttributes;
using UnityEngine;

namespace Gameplay
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private float scoreIncreaseSpeed;

        public static float currentScore { get; private set; }
        public static int bestScore { get; private set; }

        private bool playerIsAlive;

        private void Awake()
        {
            playerIsAlive = true;
            currentScore = 0;
            LoadBestScore();
        }
        private void OnEnable()
        {
            Player.OnPlayerDeathEvent += OnPlayerDeath;
        }
        private void OnDisable()
        {
            Player.OnPlayerDeathEvent -= OnPlayerDeath;
        }
        private void Update()
        {
            if (playerIsAlive) IncreaseScore();

            if (currentScore > bestScore)
            {
                SaveCurrentScore();
                LoadBestScore();
            }
        }
        private void IncreaseScore()
        {
            currentScore += scoreIncreaseSpeed * Time.deltaTime;
        }
        [Button]
        private void SaveCurrentScore()
        {
            ScoreSaver.SaveScore((int)currentScore);
        }
        [Button]
        private void LoadBestScore()
        {
            bestScore = ScoreSaver.LoadScore();
        }
        [Button]
        private void ResetScore()
        {
            ScoreSaver.SaveScore(0);
            bestScore = ScoreSaver.LoadScore();
        }
        private void OnPlayerDeath()
        {
            playerIsAlive = false;
        }
    }
}
