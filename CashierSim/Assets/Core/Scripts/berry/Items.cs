using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 screenbounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        if (transform.position.x < screenbounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
