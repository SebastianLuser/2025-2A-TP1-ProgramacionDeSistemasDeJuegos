using UnityEngine;

namespace Excercise1
{
    public class EnemyMovement : MonoBehaviour
    {
         private float _speed;
        public void InitializeSpeed(float speed)
        {
            _speed = speed <= 0f ? 5f : speed;
        }
        public void MoveTo(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - transform.position;
            transform.position += direction.normalized * (_speed * Time.deltaTime);
        }
    }
}