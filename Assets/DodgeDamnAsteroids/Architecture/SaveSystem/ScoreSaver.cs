using UnityEngine;

public static class ScoreSaver
{
    private const string DATA_KEY = "Data.json";

    public static void SaveScore(int scoreValue)
    {
        Score score = new Score { score = scoreValue };
        SaveSystem.SaveToFile(score, DATA_KEY);
    }
    public static int LoadScore()
    {
        var obj = SaveSystem.LoadFromFile<Score>(DATA_KEY);

        Score score = obj;
        return score.score;
    }
}
