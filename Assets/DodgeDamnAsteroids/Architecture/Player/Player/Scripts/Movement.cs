using UnityEngine;

namespace Gameplay
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed = 20;
        [SerializeField] private float maxX;
        [SerializeField] private float maxY;
        [SerializeField] private float minY;
        private int speedMultiplier = 10;
        private Rigidbody2D rb;
        private float horizontalSpeed;
        private float verticalSpeed;
        private void OnEnable()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            Rotate();
        }
        private void FixedUpdate()
        {
            Move();
        }
        private void Move()
        {
            horizontalSpeed = InputManager.horizontalSpeed;
            verticalSpeed = InputManager.verticalSpeed;

            CheckPosition();

            rb.velocity = new Vector2(horizontalSpeed * moveSpeed * speedMultiplier * Time.fixedDeltaTime, verticalSpeed * moveSpeed * speedMultiplier * Time.fixedDeltaTime);
        }
        private void CheckPosition()
        {
            if (transform.position.x <= -maxX && horizontalSpeed < 0 || transform.position.x >= maxX && horizontalSpeed > 0)
                horizontalSpeed = 0;

            if (transform.position.y <= minY && verticalSpeed < 0 || transform.position.y >= maxY && verticalSpeed > 0)
                verticalSpeed = 0;
        }
        private void Rotate()
        {
            float rotDirection = InputManager.horizontalSpeed;
            transform.rotation = Quaternion.Euler(0f, 0f, -rotDirection * rotationSpeed);
        }
    }
}
