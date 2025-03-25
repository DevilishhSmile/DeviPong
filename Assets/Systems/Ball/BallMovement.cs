using UnityEngine;

namespace Systems.Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float maxBounceAngle = 75f;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            ResetBall();
            LaunchBall();
        }

        void LaunchBall()
        {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(-0.5f, 0.5f);
            Vector2 direction = new Vector2(x, y).normalized;
            _rigidbody2D.linearVelocity = direction * speed;
        }

        public void ResetBall()
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
            transform.position = Vector2.zero;
            LaunchBall();
        }
    }
}