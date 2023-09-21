using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TextMeshProUGUI alarm;
        [SerializeField] private Image image;

        private void Update()
        {
            bool isOnFire = Gameplay.Fire.isOnFire;
            text.enabled = isOnFire;
            image.enabled= isOnFire;

            alarm.enabled = isOnFire;

            ShowFireLevel();
        }
        private void ShowFireLevel()
        {
            text.text = ((int)Gameplay.Fire.fireLevel).ToString() + "%";
        }
    }
}
