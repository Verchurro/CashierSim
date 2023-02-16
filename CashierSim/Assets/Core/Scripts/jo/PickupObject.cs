using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject Objects;
    private Rigidbody ObjectsRB;

    

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ButtonMouse 0");
            if (Objects == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    Debug.Log("PickupObjet");
                    PickupObjet(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
                Debug.Log("DropObj");
            }
        }
        if (Objects != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(Objects.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - Objects.transform.position);
            ObjectsRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObjet(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            ObjectsRB = pickObj.GetComponent<Rigidbody>();
           // ObjectsRB.useGravity = false;
            ObjectsRB.drag = 10;
            //ObjectsRB.constraints = RigidbodyConstraints.FreezeRotation;

            ObjectsRB.transform.parent = holdArea;
            Objects = pickObj;
        }
    }

    void DropObject()
    {
        ObjectsRB.useGravity = true;
        ObjectsRB.drag = 1;
        //ObjectsRB.constraints = RigidbodyConstraints.None;

        Objects.transform.parent = null;
        Objects = null;


    }
}
