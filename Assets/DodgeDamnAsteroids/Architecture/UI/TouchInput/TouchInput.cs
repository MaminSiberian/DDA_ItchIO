using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button shootButton;

    public static float horizontalAxis { get; private set; }
    public static float verticalAxis { get; private set; }

    private void OnEnable()
    {
        PauseMenu.OnPauseActivatedEvent += TurnOffInput;
        PauseMenu.OnPauseDeactivatedEvent += TurnOnInput;
        Player.OnPlayerDeathEvent += TurnOffInput;
    }
    private void OnDisable()
    {
        PauseMenu.OnPauseActivatedEvent -= TurnOffInput;
        PauseMenu.OnPauseDeactivatedEvent -= TurnOnInput;
        Player.OnPlayerDeathEvent -= TurnOffInput;
    }
    private void Start()
    {
        if (InputManager.inputType != InputType.Touch)
            this.gameObject.SetActive(false);
    }
    private void Update()
    {
        horizontalAxis = joystick.Horizontal;
        verticalAxis = joystick.Vertical;
    }
    private void TurnOffInput()
    {
        joystick.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        shootButton.gameObject.SetActive(false);
    }
    private void TurnOnInput()
    {
        joystick.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        shootButton.gameObject.SetActive(true);
    }
}
