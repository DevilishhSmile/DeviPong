using UnityEngine;

namespace Systems.Paddle
{
    [AddComponentMenu("DeviPong/Paddle/Paddle Data")]
    public class PaddleData : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float maxBounceAngle = 75f;
        private Rigidbody2D _rigidbody2D;
        private Collider2D _collider;
        private Transform _transform;
        
        public float Speed => speed;
        public float MaxBounceAngle => maxBounceAngle;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Collider2D Collider => _collider;
        public Transform Transform => _transform;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            _transform = transform;
        }
    }
}