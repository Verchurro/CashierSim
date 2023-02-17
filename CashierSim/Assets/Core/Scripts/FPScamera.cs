using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FPScamera : MonoBehaviour
{
    [SerializeField]
    float mouseSensibilityX;

    [SerializeField]
    float mouseSensibilityY;

    [SerializeField]
    Transform PlayerOrientation;

    float cameraRotationX;
    float cameraRotationY;

    void GetMouseInput()
    {
        float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSensibilityX;
        float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensibilityY;
        cameraRotationY += _mouseX;
        cameraRotationX -= _mouseY;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -30f, 40f);
        cameraRotationY = Mathf.Clamp(cameraRotationY, 0, 180);

        transform.rotation = Quaternion.Euler(cameraRotationX, cameraRotationY, 0);
        PlayerOrientation.rotation = Quaternion.Euler(0, cameraRotationY, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseInput();
    }
}