using System;
using UnityEngine;

namespace Gameplay
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] private float fuelConsumptionSpeed;
        [SerializeField] private float refuelingSpeed;
        [SerializeField] private int fuelInCanister;

        public static float fuelValue { get; private set; }
        public static event Action OnGetCanisterEvent;

        private int maxFuelValue = 100;
        private Player player;
        private bool isRefueling;
        private float newFuelValue;

        private string canisterTag = TagStorage.canisterTag;
        private string causeOfDeath = "You are out of fuel!";

        private void Awake()
        {
            fuelValue = maxFuelValue;
            player = GetComponent<Player>();
        }
        private void Update()
        {
            if (fuelValue > maxFuelValue)
                fuelValue = maxFuelValue;
            if (fuelValue <= 0)
            {
                fuelValue = 0;
                player.KillPlayer(causeOfDeath);
            }

            if (isRefueling)
            {
                Refuel();
                return;
            }

            ConsumpFuel();
        }
        private void ConsumpFuel()
        {
            fuelValue -= fuelConsumptionSpeed * Time.deltaTime;
        }
        private void Refuel()
        {
            if (fuelValue >= newFuelValue)
            {
                isRefueling = false;
                return;
            }

            fuelValue += refuelingSpeed * Time.deltaTime;
        }
        public void GetCanister()
        {
            OnGetCanisterEvent?.Invoke();

            if (isRefueling) 
                newFuelValue += fuelInCanister;
            else
                newFuelValue = fuelValue + fuelInCanister;

            if (newFuelValue > 100) newFuelValue = 100;

            SoundsManager.PlayRefuelSound();
            isRefueling = true;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(canisterTag))
            {
                GetCanister();
            }
        }
    }
}
