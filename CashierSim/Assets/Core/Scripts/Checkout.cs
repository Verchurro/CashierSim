using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkout : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Client")
        { 
            spawner.SetActive(true);
            Debug.Log("In");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Client")
        {
            spawner.SetActive(false);
            Debug.Log("out");
        }
    }

}
