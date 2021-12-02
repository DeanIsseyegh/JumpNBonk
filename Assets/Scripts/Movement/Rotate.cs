using UnityEngine;

namespace Movement
{
    public class Rotate : MonoBehaviour
    {

        [SerializeField] private float rotateSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }
    }
}
