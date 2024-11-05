using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTouch : MonoBehaviour
{
    public string sceneName = "tierra"; // Nombre de la escena a la que deseas cambiar

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Hand"
        if (other.CompareTag("Hand"))
        {
            // Cambia a la escena especificada
            SceneManager.LoadScene(sceneName);
        }
    }
}
