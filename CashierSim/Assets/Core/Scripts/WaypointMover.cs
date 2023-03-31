using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    //Reference to the waypoint script
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    [SerializeField] private float rotateSpeed = 4f;
    [SerializeField]Transform stoppingPoint;
    [SerializeField] Spawner spawner;
    public bool canMove = true;

    //the current waypoint target that the object is moving to
    private Transform currentWaypoint;
    //The rotation target for the current frame
    private Quaternion rotationGoal;
    //direction to the next waypoint that agents rotating towards
    private Vector3 directionToWaypoint;
    
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
        if (canMove&& Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            if (currentWaypoint.position == stoppingPoint.position)
            {
                canMove = false;
                return;
            } 

            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
           //transform.LookAt(currentWaypoint);
        }
        RotateToWaypoint();
    }

    //will slowly rotate agent towards current waypoint its goin to
    private void RotateToWaypoint()
    {
        directionToWaypoint= (currentWaypoint.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }

    public void ExitStore()
    {
        canMove= true;
        stoppingPoint= null;
    }
}
