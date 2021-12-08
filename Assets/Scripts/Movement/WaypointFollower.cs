using UnityEngine;

namespace Movement
{
    public class WaypointFollower : MonoBehaviour
    {
        private int _waypointIndex;

        [SerializeField] private GameObject[] waypoints;
        [SerializeField] private float speed = 2f;

        private void Update()
        {
            if (_waypointIndex >= waypoints.Length) Debug.Log("ERROR HERE " + gameObject.name);
            Vector2 waypointPos = waypoints[_waypointIndex].transform.position;
            if (Vector2.Distance(waypointPos, transform.position) < .1f)
            {
                _waypointIndex = _waypointIndex == waypoints.Length-1 ? 0 : _waypointIndex + 1;
            }
            transform.position = Vector2.MoveTowards(transform.position, waypointPos, speed * Time.deltaTime);
        }
    }
}