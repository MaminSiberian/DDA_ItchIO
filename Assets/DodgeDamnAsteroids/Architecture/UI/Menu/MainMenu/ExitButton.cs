using UnityEngine;

public class ExitButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        Application.Quit();
    }
}
