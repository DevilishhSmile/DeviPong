using Systems.Ball;
using UnityEngine;

namespace Systems.Environment
{
    [AddComponentMenu("DeviPong/Environment/Wall Collision")]
    public class WallCollision : MonoBehaviour, ICollision
    {
        public void OnCollision(BallData ballData)
        {
            Rigidbody2D ballRigidbody2D = ballData.Rigidbody2D;
            ballRigidbody2D.linearVelocityY *= -1;
            
            ballData.AmountWallHits.Value++;
        }
    }
}