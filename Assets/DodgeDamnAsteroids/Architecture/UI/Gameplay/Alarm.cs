using UnityEngine;
using TMPro;
using DG.Tweening;

namespace UI
{
    public class Alarm : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private Color white = Color.white;
        private Color red = Color.red;
        private float speed = 1f;
        private Tween tween;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            text.color = white;
        }
        private void Update()
        {
            if (text.color == white)
            {
                tween.Kill();
                tween = text.DOColor(red, speed);
            }

            if (text.color == red)
            {
                tween.Kill();
                tween = text.DOColor(white, speed);
            }
        }
        private void OnDisable()
        {
            tween.Kill();
        }
    }
}
