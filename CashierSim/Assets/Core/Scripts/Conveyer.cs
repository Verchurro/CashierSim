using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer : MonoBehaviour
{
    [SerializeField] float speed = 0.005f;
    private void OnTriggerStay(Collider other)
    {
        other.gameObject.transform.Translate(gameObject.transform.forward * speed);
    }

}
