using UnityEngine;

namespace Excercise1
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private bool lookAtTarget = true;
        
        public void MoveTo(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - transform.position;
            transform.position += direction.normalized * (speed * Time.deltaTime);
            
            if (lookAtTarget)
            {
                transform.LookAt(new Vector3(targetPosition.x, targetPosition.y, transform.position.z));
            }
        }
        
        public void SetSpeed(float newSpeed)
        {
            if (newSpeed <= 0)
            {
                speed = 5f;
                return;
            }
            
            speed = newSpeed;
        }
        
        public float GetSpeed()
        {
            return speed;
        }
    }
}