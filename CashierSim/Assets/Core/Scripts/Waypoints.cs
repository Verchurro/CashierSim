using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Waypoints : MonoBehaviour
{
    //needa add that if certain amount of items r spawned, leave
    [Range(0f, 4f)]
    [SerializeField] private float waypointSize = 1f;
  
    [Header("Path Settings")]
    //Makes client loop
    [SerializeField] private bool canLoop = true;
    private void OnDrawGizmos()
    {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }
        Gizmos.color= Color.red;
        for(int i = 0; i < transform.childCount -1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        //if path is set to loop, draw a line between first and last waypoint
        if (canLoop)
        {
            Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
        }
        
    }

    // Will get the correct next waypoint based on the direction client is currently traveling
    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
       if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }
        if (currentWaypoint.GetSiblingIndex()< transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex()+1);
        }
        else
        {
            if (canLoop)
            {
              return transform.GetChild(0);
            }
            else
            {
                return transform.GetChild(currentWaypoint.GetSiblingIndex());
            }
           
        }
    }
}


