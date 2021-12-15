using UnityEngine;

namespace Movement
{
    public class DestroyAfterOnTrigger : MonoBehaviour
    {

        [SerializeField] private string otherTag;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(otherTag))
            {
                Destroy(gameObject);
            }
        }
    }
}
