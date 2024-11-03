using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers; // Opciones A,B,C,D
    public int correctAnswerIndex;
}

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;          
    public Button[] answerButtons;                
    public Image[] answerHighlights;              

    public List<Question> questions;              
    public Color correctColor = new Color(0, 1, 0, 0.5f);   
    public Color incorrectColor = new Color(1, 0, 0, 0.5f); 

    private int currentQuestionIndex = 0;         
    private int incorrectAnswers = 0;

    // Start is called before the first frame update
    void Start()
    {
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        Question currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.questionText;

        // Loop through each answer option to display and reset highlights
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Set the answer text on each button
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.answers[i];

            // Reset highlight to transparent
            answerHighlights[i].color = new Color(0, 0, 0, 0);

            // Remove previous listeners and add new one
            int index = i; // Capture index for delegate
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
        }
    }

    public void OnAnswerSelected(int selectedIndex)
    {
        Question currentQuestion = questions[currentQuestionIndex];

        // Clear all highlights
        for (int i = 0; i < answerHighlights.Length; i++)
        {
            answerHighlights[i].color = new Color(0, 0, 0, 0); // Make all highlights transparent initially
        }

        if (selectedIndex == currentQuestion.correctAnswerIndex)
        {
            // Correct answer: show green highlight
            answerHighlights[selectedIndex * 2].color = correctColor; // Even indices for green highlights
            StartCoroutine(NextQuestionWithDelay());
        }
        else
        {
            // Incorrect answer: show red highlight
            answerHighlights[selectedIndex * 2 + 1].color = incorrectColor; // Odd indices for red highlights
            incorrectAnswers++;

            if (incorrectAnswers >= 3)
            {
                StartCoroutine(RestartQuizWithDelay());
            }
        }
    }


    IEnumerator NextQuestionWithDelay()
    {
        yield return new WaitForSeconds(1f); // Pause to show the highlight
        incorrectAnswers = 0; // Reset incorrect answers for the next question
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Game completed!"); // Add end game logic here if needed
            // You could restart or show a completion message
        }
    }

    IEnumerator RestartQuizWithDelay()
    {
        yield return new WaitForSeconds(1f); // Pause to show the incorrect highlight
        incorrectAnswers = 0;                // Reset the incorrect answers counter
        currentQuestionIndex = 0;            // Reset to the first question
        DisplayQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        // Detect mouse clicks on buttons to simulate VR button presses
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    HandleButtonClick(hit.collider.gameObject);
                }
            }
        }
    }

    void HandleButtonClick(GameObject clickedObject)
    {
        // Match the clicked button name to the appropriate index
        if (clickedObject.name == "BotonA")
            OnAnswerSelected(0);
        else if (clickedObject.name == "BotonB")
            OnAnswerSelected(1);
        else if (clickedObject.name == "BotonC")
            OnAnswerSelected(2);
        else if (clickedObject.name == "BotonD")
            OnAnswerSelected(3);
    }
}
