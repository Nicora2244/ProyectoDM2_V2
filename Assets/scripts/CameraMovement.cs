using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform cameraTransform; // Reference to the camera child

    private float rotationX = 0f; // Yaw (horizontal rotation)
    private float rotationY = 0f; // Pitch (vertical rotation)

    void Start()
    {
        Vector3 rotation = transform.eulerAngles;
        rotationX = rotation.y;
        rotationY = cameraTransform.localEulerAngles.x;
    }

    void Update()
    {
        // Rotate camera only when right mouse button is held
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            rotationX += mouseX; // Horizontal rotation (yaw)
            rotationY -= mouseY; // Vertical rotation (pitch)
            rotationY = Mathf.Clamp(rotationY, -90f, 90f); // Clamp vertical rotation to avoid flipping

            // Apply yaw to the pivot (horizontal rotation)
            transform.localRotation = Quaternion.Euler(0f, rotationX, 0f);

            // Apply pitch to the camera (vertical rotation)
            cameraTransform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}


/* public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Variables para la entrada del teclado
        float moveHorizontal = Input.GetAxis("Horizontal"); // A y D
        float moveVertical = Input.GetAxis("Vertical");     // W y S

        // Movimiento basado en el input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Aplicar el movimiento a la cámara
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}*/


