using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TextMeshProUGUI alarm;

        private Animator animator;
        private string refuelAnimName = "Refuel";
        private int criticalValue = 25;

        private void OnEnable()
        {
            animator = image.GetComponent<Animator>();
            Gameplay.Fuel.OnGetCanisterEvent += OnGetCanister;
        }
        private void OnDisable()
        {
            Gameplay.Fuel.OnGetCanisterEvent -= OnGetCanister;
        }
        private void Update()
        {
            ShowFuelLevel();
        }
        private void ShowFuelLevel()
        {
            int value = (int)Gameplay.Fuel.fuelValue;
            text.text = value.ToString() + "%";

            alarm.enabled = value < criticalValue;
        }
        private void OnGetCanister()
        {
            animator.Play(refuelAnimName);
        }
    }
}
