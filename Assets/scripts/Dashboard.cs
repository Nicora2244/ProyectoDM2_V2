using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dashboard : MonoBehaviour
{
    public TextMeshProUGUI scoredText;
    public TextMeshProUGUI missedText;
    public TextMeshProUGUI correctAnswersText;
    public TextMeshProUGUI wrongAnswersText;

    void Start()
    {
        UpdateDashboard();
    }

    void UpdateDashboard()
    {
        scoredText.text = "Encestadas: " + Estadisticas.Instance.objectsScored;
        missedText.text = "Falladas: " + Estadisticas.Instance.objectsMissed;
        correctAnswersText.text = "Respuestas Correctas: " + Estadisticas.Instance.correctAnswers;
        wrongAnswersText.text = "Respuestas Incorrectas: " + Estadisticas.Instance.wrongAnswers;
    }

    public void OnExitButton()
    {
        Debug.Log("Se esta saliendo del juego...");
        Application.Quit(); // Sale del juego
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("menu"); // Carga la escena del menú principal
    }
}
