using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterTime : MonoBehaviour
{
    public string sceneName = "Tierra"; // Nombre de la escena a la que deseas cambiar
    public float delayTime = 40f;       // Tiempo de espera en segundos

    private void Start()
    {
        // Inicia el cambio de escena después del tiempo especificado
        Invoke("ChangeScene", delayTime);
    }

    private void ChangeScene()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(sceneName);
    }
}
