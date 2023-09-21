using UnityEngine;
using TMPro;
using DG.Tweening;
using Gameplay;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI causeOfDeathText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject buttons;

    private Tween tween;
    private float duration = 2;

    private void Awake()
    {
        gameOverText.enabled = false;
        causeOfDeathText.enabled = false;
        scoreText.enabled = false;
        buttons.SetActive(false);
    }
    private void OnEnable()
    {
        Player.OnPlayerDeathEvent += ActivateScreen;
    }
    private void OnDisable()
    {
        Player.OnPlayerDeathEvent -= ActivateScreen;
        tween.Kill();
    }

    private void ActivateScreen()
    {
        ShowGameOverText();
    }
    private void ShowGameOverText()
    {
        gameOverText.enabled = true;
        SetZeroAlpha(gameOverText);
        tween = gameOverText.DOFade(1, duration).OnKill(() => ShowCauseText());
    }
    private void ShowCauseText()
    {
        causeOfDeathText.text = Player.causeOfDeath;
        causeOfDeathText.enabled = true;
        SetZeroAlpha(causeOfDeathText);
        tween = causeOfDeathText.DOFade(1, duration).OnKill(() => ShowScoreText());
    }
    private void ShowScoreText()
    {
        scoreText.text = "Your score: " + ((int)ScoreCounter.currentScore).ToString();
        scoreText.enabled = true;
        SetZeroAlpha(scoreText);
        tween = scoreText.DOFade(1, duration).OnKill(() => ShowButtons());
    }
    private void ShowButtons()
    {
        buttons.SetActive(true);
    }

    private void SetZeroAlpha(TextMeshProUGUI text)
    {
        Color color = text.color;
        color.a = 0;
        text.color = color;
    }
}
