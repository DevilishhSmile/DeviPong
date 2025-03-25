using Systems.Ball;
using UnityEngine;

namespace Systems.Paddle
{
    [AddComponentMenu("DeviPong/Paddle/Paddle Collision")]
    public class PaddleCollision : MonoBehaviour, ICollision
    {
        private PaddleData _paddleData;
        
        private void Awake()
        {
            _paddleData = GetComponent<PaddleData>();
        }
        
        public void OnCollision(BallData ballData)
        {
            Transform paddleTransform = _paddleData.Transform;
            Collider2D paddleCollider = _paddleData.Collider;
            float maxBounceAngle = _paddleData.MaxBounceAngle;
            float ballSpeed = ballData.Speed;
            
            Transform ballTransform = ballData.Transform;
            Rigidbody2D ballRigidbody2D = ballData.Rigidbody2D;
            
            Vector3 ballPos = ballTransform.position;
            Vector3 paddlePosition = paddleTransform.position;
            float paddleHeight = paddleCollider.bounds.size.y;
            float contactY = ballPos.y - paddlePosition.y;
            
            float normalizedY = Mathf.Clamp(contactY / (paddleHeight / 2f), -1f, 1f);
            float bounceAngle = normalizedY * maxBounceAngle * Mathf.Deg2Rad;
            
            float directionX = ballRigidbody2D.linearVelocity.x > 0 ? -1f : 1f;
            Vector2 newDirection = new Vector2(Mathf.Cos(bounceAngle) * directionX, Mathf.Sin(bounceAngle)).normalized;
            
            ballRigidbody2D.linearVelocity = newDirection * ballSpeed;
        }
    }
}