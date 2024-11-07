using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estadisticas : MonoBehaviour
{
    public static Estadisticas Instance;

    public int objectsScored = 0;
    public int objectsMissed = 0;
    public int correctAnswers = 0;
    public int wrongAnswers = 0;

    private void Awake()
    {
        // Asegura que solo exista una instancia de GameStats
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Hace que el objeto persista entre escenas
        }
        else
        {
            Destroy(gameObject); // Elimina objetos duplicados
        }
    }

    public void ResetStats()
    {
        objectsScored = 0;
        objectsMissed = 0;
        correctAnswers = 0;
        wrongAnswers = 0;
    }
}
