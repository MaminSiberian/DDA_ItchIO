using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private List<Image> bombs= new List<Image>();

        private int maxAmmo;
        private int ammo;
        private string burningAnimName = "Burning";
        private string idleAnimName = "Idle";

        private void Start()
        {
            if (bombs.Count != Gameplay.Gun.maxAmmo)
            {
                Debug.Log("Check bombs amount in UI!");
            }

            maxAmmo = Gameplay.Gun.maxAmmo;
            bombs.ForEach(b => b.enabled = false);

            ShowAmmo();
        }
        private void Update()
        {
            if (ammo != Gameplay.Gun.ammo)
                ShowAmmo();

            if (ammo != maxAmmo)
                ShowReloading();
        }
        private void ShowAmmo()
        {
            ammo = Gameplay.Gun.ammo;

            for (int i = 0; i < bombs.Count; i++)
            {
                bombs[i].enabled = i <= ammo;
                if (i < ammo)
                {
                    bombs[i].fillAmount = 1;
                    bombs[i].GetComponent<Animator>().Play(burningAnimName);
                }
            }
        }
        private void ShowReloading()
        {
            bombs[ammo].GetComponent<Animator>().Play(idleAnimName);
            bombs[ammo].fillAmount = Gameplay.Gun.reloadProgress;
        }
    }
}
