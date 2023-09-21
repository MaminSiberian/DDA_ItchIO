
public class QuitButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        PauseMenu.UnpauseGame();
        SceneDirector.ReturnToMainMenu();
    }
}
