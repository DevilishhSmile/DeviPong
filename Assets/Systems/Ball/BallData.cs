using Systems.Paddle;
using Systems.Utils;
using UnityEngine;

namespace Systems.Ball
{
    [AddComponentMenu("DeviPong/Ball/Ball Data")]
    public class BallData : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;

        public float Speed => speed;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Transform Transform => _transform;
        
        public ReactiveVariable<PaddleData> LastPaddleHit { get; private set; } = new ReactiveVariable<PaddleData>();
        public ReactiveVariable<int> AmountPaddleHits { get; private set; } = new ReactiveVariable<int>();
        public ReactiveVariable<int> AmountWallHits { get; private set; } = new ReactiveVariable<int>();
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
        }
        
    }
}