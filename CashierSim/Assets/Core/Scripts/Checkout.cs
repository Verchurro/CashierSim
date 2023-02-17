using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkout : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject bullet;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Client")
        {
            Debug.Log("In");
            spawner.SetActive(true);
        }
    }

}
