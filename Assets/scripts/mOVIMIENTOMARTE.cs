using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mOVIMIENTOMARTE : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Crear un vector de movimiento inicial en cero
        Vector3 movement = Vector3.zero;

        // Detectar teclas específicas y aplicar el movimiento correspondiente
        if (Input.GetKey(KeyCode.A)) // Avanzar
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D)) // Retroceder
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.S)) // Izquierda
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.W)) // Derecha
        {
            movement += Vector3.right;
        }

        // Aplicar el movimiento al transform
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}