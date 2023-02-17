using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    //Reference to the waypoint script
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    //the current waypoint target that the object is moving to
    private Transform currentWaypoint;
    void Start()
    {
        //Set initial position to the first waypoint
        currentWaypoint= waypoints.GetNextWaypoint(currentWaypoint);
        transform.position= currentWaypoint.position;

        //set the next waypoint target, what were gonna move towards
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, currentWaypoint.position, movespeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
        }
    }
}
