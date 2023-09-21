using UnityEngine.SceneManagement;

public static class SceneDirector
{
    private static string mainMenuSceneName = "MainMenu";
    private static string gameSceneName = "Game";

    public static void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
