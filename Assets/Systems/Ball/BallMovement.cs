using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems.Ball
{
    [AddComponentMenu("DeviPong/Ball/Ball Movement")]
    public class BallMovement : MonoBehaviour
    {
        private BallData _ballData;
        
        private void Awake()
        {
            _ballData = GetComponent<BallData>();
        }

        private void OnEnable()
        {
            _ballData.AmountWallHits.OnValueChanged += OnWallHit;
        }

        private void OnDisable()
        {
            _ballData.AmountWallHits.OnValueChanged -= OnWallHit;
        }

        void Start()
        {
            ResetBall();
            LaunchBall();
        }
        
        public void LaunchBall()
        {
            Rigidbody2D ballRigidbody2D = _ballData.Rigidbody2D;
            float ballSpeed = _ballData.Speed;
            
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(-0.5f, 0.5f);
            Vector2 direction = new Vector2(x, y).normalized;
            ballRigidbody2D.linearVelocity = direction * ballSpeed;
        }
        
        public void ResetBall()
        {
            Rigidbody2D ballRigidbody2D = _ballData.Rigidbody2D;
            
            ballRigidbody2D.linearVelocity = Vector2.zero;
            transform.position = Vector2.zero;
        }
        
        private void OnWallHit(int amountHits)
        {
            if (amountHits > 0)
            {
                
            }
        }
    }
}