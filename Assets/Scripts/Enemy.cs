using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        // assign first waypoint as a target
        target = Waypoints.waypoints[0];
    }

    void Update()
    {
        // direction = destination - enemy current position
        Vector3 direction = target.position - transform.position; 
        // Moves the transform in the direction and distance of translation relative to space
        // vector is normalized to indicate only the direction, multiplying by deltaTime to maintain constant speed independent of frames passed   
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.025f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
