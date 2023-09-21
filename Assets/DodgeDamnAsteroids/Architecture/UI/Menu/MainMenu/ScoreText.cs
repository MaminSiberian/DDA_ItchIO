using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        LoadScore();
    }
    private void LoadScore()
    {
        text.text = "Best score: " + ScoreSaver.LoadScore().ToString();
    }
    [Button]
    private void ResetScore()
    {
        ScoreSaver.SaveScore(0);
        LoadScore();
    }
}
