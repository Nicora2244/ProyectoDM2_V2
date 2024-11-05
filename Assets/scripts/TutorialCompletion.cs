using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TutorialCompletion : MonoBehaviour
{
    public TextMeshProUGUI progressText; // Referencia al texto de progreso en el Canvas
    public TextMeshProUGUI completionMessage; // Referencia al mensaje de finalización
    public string sceneName = "tierra"; // Nombre de la escena a la que deseas cambiar
    private int objectsPassedThroughRing = 0; // Contador de objetos

    private void Start()
    {
        // Inicializa el contador y oculta el mensaje de finalización al inicio
        UpdateProgressText();
        completionMessage.gameObject.SetActive(false); // Oculta el mensaje al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que pasa es uno de los objetos del tutorial
        if (other.CompareTag("Disco") || other.CompareTag("Lingote") || other.CompareTag("Pelota"))
        {
            objectsPassedThroughRing++;
            UpdateProgressText();

            // Verifica si los tres objetos han pasado por el aro
            if (objectsPassedThroughRing >= 3)
            {
                ShowCompletionMessage();
                StartCoroutine(WaitAndChangeScene());
            }
        }
    }

    private void UpdateProgressText()
    {
        // Actualiza el texto de progreso en el Canvas
        progressText.text = $"{objectsPassedThroughRing}/3";
    }

    private void ShowCompletionMessage()
    {
        // Muestra el mensaje de finalización del tutorial
        completionMessage.text = "¡Finalizaste el tutorial!";
        completionMessage.gameObject.SetActive(true);
    }

    private IEnumerator WaitAndChangeScene()
    {
        // Espera 5 segundos y cambia a la escena especificada
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneName);
    }
}
