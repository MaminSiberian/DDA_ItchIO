using UnityEngine;

public class PCInputHandler : MonoBehaviour, IInputHandler
{
    private Gameplay.Gun gun;

    private KeyCode shootKey = KeyCode.Space;
    private KeyCode pauseKey = KeyCode.Escape;
    private bool isPaused = false;

    private void Awake()
    {
        gun = FindAnyObjectByType<Gameplay.Gun>();
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
        if (Input.GetKeyDown(shootKey))
        {
            this.Shoot();
        }

        if (Input.GetKeyDown(pauseKey))
        {
            if (!isPaused) this.PauseGame();
            else this.UnpauseGame();
        }
    }
    public void Shoot()
    {
        gun.Shoot();
    }
    public float HorizontalSpeed()
    {
        return Input.GetAxis("Horizontal");
    }
    public float VerticalSpeed()
    {
        return Input.GetAxis("Vertical");
    }
    private void PauseGame()
    {
        PauseMenu.PauseGame();
        isPaused = true;
    }
    private void UnpauseGame()
    {
        PauseMenu.UnpauseGame();
        isPaused = false;
    }
    private void OnPlayerDeath()
    {
        this.gameObject.SetActive(false);
    }
}
