using Systems.Paddle;
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
        
        public PaddleData LastPaddleHit { get; set; }
        public int AmountPaddleHits { get; set; }
        public int AmountWallHits { get; set; }
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
        }
        
    }
}