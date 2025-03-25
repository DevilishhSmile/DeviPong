using UnityEngine;

namespace Systems.Paddle
{
    [AddComponentMenu("DeviPong/Paddle/Paddle Movement")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PaddleMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private InputReader inputReader;
        
        private Rigidbody2D _rigidbody2D;
        private float _verticalInput;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void Start()
        {
            inputReader.Move += ChangeDirection;
            inputReader.EnablePlayerAction();
        }
        
        private void ChangeDirection(Vector2 direction)
        {
            _verticalInput = direction.y;
        }
        
        private void FixedUpdate()
        {
            _rigidbody2D.linearVelocityY = _verticalInput * speed;
        }
    }
}