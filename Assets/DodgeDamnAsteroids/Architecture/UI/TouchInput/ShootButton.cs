using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour
{
    private Button button;
    private Gameplay.Gun gun;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void OnEnable()
    {
        gun = FindAnyObjectByType<Gameplay.Gun>();
        button.onClick.AddListener(Shoot);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(Shoot);
    }
    private void Shoot()
    {
        gun.Shoot();
    }
}
