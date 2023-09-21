using UnityEngine;

namespace Gameplay
{
    public class Alarm : MonoBehaviour
    {
        private AudioSource audioSource;
        private int criticalValue = 25;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.enabled = false;
        }
        private void Update()
        {
            if (Time.timeScale == 0)
            {
                audioSource.enabled = false;
                return;
            }

            audioSource.enabled = Fire.isOnFire || Fuel.fuelValue < criticalValue;
        }
    }
}
