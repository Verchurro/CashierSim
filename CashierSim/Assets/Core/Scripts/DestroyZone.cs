using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    [SerializeField] private GameObject cube;


    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject, 3);
        Debug.Log("collided");

    }
}