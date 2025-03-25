using Systems.Ball;
using UnityEngine;

namespace Systems.Flags
{
    [AddComponentMenu("DeviPong/Flags/Flag Collision")]
    public class FlagCollision : MonoBehaviour, ICollision
    {
        public void OnCollision(BallData ballData)
        {
            BallMovement ballMovement = ballData.GetComponent<BallMovement>();
            ballMovement.ResetBall();
            ballMovement.LaunchBall();
        }
    }
}