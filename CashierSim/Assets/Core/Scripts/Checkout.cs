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
            Debug.Log("In");
            spawner.SetActive(true);
        }
    }

}
