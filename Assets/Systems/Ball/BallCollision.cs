using UnityEngine;

namespace Systems.Ball
{
    [AddComponentMenu("DeviPong/Ball/Ball Collision")]
    public class BallCollision : MonoBehaviour
    {
        private BallData _ballData;
        
        private void Awake()
        {
            _ballData = GetComponent<BallData>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out ICollision collisionComponent))
            {
                collisionComponent.OnCollision(_ballData);
            }
        }
    }
}