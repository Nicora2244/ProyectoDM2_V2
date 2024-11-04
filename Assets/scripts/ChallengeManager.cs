using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Para cambiar de escena

public class ChallengeManager : MonoBehaviour
{
    public Text challengeText; // Texto UI para mostrar el reto
    public Text timerText; // Texto UI para mostrar el tiempo restante
    public GameObject losePanel; // El panel que aparecerá cuando el jugador pierda
    public GameObject questionPanel; // Panel de la pregunta
    public Text questionText; // Texto de la pregunta
    public Button[] answerButtons; // Botones de respuesta
    public Button retryButton; // Botón para reintentar
    public string environment; // Asigna "Earth", "Moon" o "Mars" en el Inspector según la escena

    private float timeRemaining = 30f;
    private bool challengeActive = true;
    private int objectsScored = 0; // Contador de objetos encestados
    private int totalObjectsToScore = 3; // Total de objetos necesarios para ganar
    private bool questionAnswered = false; // Indica si la pregunta ya fue respondida

    void Start()
    {
        losePanel.SetActive(false); // Asegurarse de que el panel esté desactivado al inicio
        questionPanel.SetActive(false); // Asegurarse de que el panel de pregunta esté desactivado al inicio
        retryButton.onClick.AddListener(RestartChallenge); // Asignar la función al botón de reintento
        UpdateChallengeText();
    }

    void Update()
    {
        if (challengeActive)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Tiempo restante: " + Mathf.Ceil(timeRemaining).ToString() + "s";

            if (timeRemaining <= 0)
            {
                LoseChallenge(); // Llamar a la función cuando se acabe el tiempo
            }
        }
    }

    public void ObjectScored()
    {
        // Incrementar el contador de objetos encestados
        objectsScored++;
        UpdateChallengeText();

        // Verificar si se ha completado el reto con 3 objetos encestados
        if (objectsScored >= totalObjectsToScore && !questionAnswered)
        {
            challengeText.text = "¡Reto completado!";
            challengeActive = false;
            ShowQuestionPanel(); // Mostrar el panel de la pregunta
        }
    }

    void ShowQuestionPanel()
    {
        questionPanel.SetActive(true);

        if (environment == "Earth")
        {
            questionText.text = "¿Cuál es la aceleración debido a la gravedad en la superficie de la Tierra?";
            answerButtons[0].GetComponentInChildren<Text>().text = "8.9 m/s²";
            answerButtons[1].GetComponentInChildren<Text>().text = "9.8 m/s²"; // Correcta
            answerButtons[2].GetComponentInChildren<Text>().text = "10.2 m/s²";
            answerButtons[3].GetComponentInChildren<Text>().text = "11.1 m/s²";

            // Asignar eventos a los botones
            answerButtons[0].onClick.AddListener(() => CheckAnswer(false));
            answerButtons[1].onClick.AddListener(() => CheckAnswer(true)); // Correcta
            answerButtons[2].onClick.AddListener(() => CheckAnswer(false));
            answerButtons[3].onClick.AddListener(() => CheckAnswer(false));
        }
        else if (environment == "Moon")
        {
            questionText.text = "¿Cuál es aproximadamente la aceleración debida a la gravedad en la superficie de la Luna?";
            answerButtons[0].GetComponentInChildren<Text>().text = "1.6 m/s²"; // Correcta
            answerButtons[1].GetComponentInChildren<Text>().text = "3.7 m/s²";
            answerButtons[2].GetComponentInChildren<Text>().text = "9.8 m/s²";
            answerButtons[3].GetComponentInChildren<Text>().text = "12.5 m/s²";

            // Asignar eventos a los botones
            answerButtons[0].onClick.AddListener(() => CheckAnswer(true)); // Correcta
            answerButtons[1].onClick.AddListener(() => CheckAnswer(false));
            answerButtons[2].onClick.AddListener(() => CheckAnswer(false));
            answerButtons[3].onClick.AddListener(() => CheckAnswer(false));
        }
        else if (environment == "Mars")
        {
            questionText.text = "¿Cuál es aproximadamente la aceleración debida a la gravedad en la superficie de Marte?";
            answerButtons[0].GetComponentInChildren<Text>().text = "3.7 m/s²"; // Correcta
            answerButtons[1].GetComponentInChildren<Text>().text = "6.4 m/s²";
            answerButtons[2].GetComponentInChildren<Text>().text = "9.8 m/s²";
            answerButtons[3].GetComponentInChildren<Text>().text = "1.6 m/s²";

            // Asignar eventos a los botones
            answerButtons[0].onClick.AddListener(() => CheckAnswer(true)); // Correcta
            answerButtons[1].onClick.AddListener(() => CheckAnswer(false));
            answerButtons[2].onClick.AddListener(() => CheckAnswer(false));
            answerButtons[3].onClick.AddListener(() => CheckAnswer(false));
        }
    }


    void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            questionText.text = "¡Respuesta correcta!";
            StartCoroutine(CompleteChallenge()); // Procede a la siguiente escena
        }
        else
        {
            questionText.text = "Respuesta incorrecta. Reintenta el reto.";
            questionAnswered = true;
            Invoke("RestartChallenge", 2f); // Reinicia el desafío después de 2 segundos
        }
    }

    IEnumerator CompleteChallenge()
    {
        yield return new WaitForSeconds(2); // Esperar un tiempo antes de cambiar de escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void LoseChallenge()
    {
        challengeActive = false;
        timerText.text = "¡Tiempo agotado!";
        challengeText.text = "Reto fallido";
        losePanel.SetActive(true); // Mostrar el panel de "Perdiste"
    }

    public void RestartChallenge()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual
    }

    void UpdateChallengeText()
    {
        challengeText.text = "Objetos encestados: " + objectsScored + "/" + totalObjectsToScore;
    }
}
