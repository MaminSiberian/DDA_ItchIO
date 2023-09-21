using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private List<Image> hearts;

        private int health;
        
        private void Start()
        {
            if (hearts.Count != Gameplay.Health.maxHealthValue)
            {
                Debug.Log("Check hearts amount in UI!");
            }

            hearts.ForEach(h => h.enabled = false);

            ShowHealth();
        }
        private void Update()
        {
            if (health != Gameplay.Health.healthValue)          
                ShowHealth();
        }

        private void ShowHealth()
        {
            health = Gameplay.Health.healthValue;
            for (int i = 0; i < hearts.Count; i++)
            {
                hearts[i].enabled = i < health;
            }
        }
    }

}
