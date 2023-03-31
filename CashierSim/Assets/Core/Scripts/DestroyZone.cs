using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Produits")
        {
            Destroy(other.gameObject);
            Debug.Log("collided");
        }
    }
}
        //to make it spawn stuff again write numbobj--
