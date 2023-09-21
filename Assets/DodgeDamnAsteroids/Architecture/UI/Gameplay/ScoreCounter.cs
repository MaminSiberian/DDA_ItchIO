using UnityEngine;
using TMPro;

namespace UI
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentScoreText;
        [SerializeField] private TextMeshProUGUI bestScoreText;

        private void Update()
        {
            ShowCurrentScore();
            ShowBestScore();
        }
        private void ShowCurrentScore()
        {
            currentScoreText.text = "Score: " + ((int)Gameplay.ScoreCounter.currentScore).ToString();
        }
        private void ShowBestScore()
        {
            bestScoreText.text = "Best: " + Gameplay.ScoreCounter.bestScore.ToString();
        }
    }
}
