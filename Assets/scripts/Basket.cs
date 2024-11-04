using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ChallengeManager challengeManager; // Referencia al ChallengeManager para notificar cuando se enceste un objeto

    void Start()
    {
        if (challengeManager == null)
        {
            challengeManager = FindObjectOfType<ChallengeManager>();
            if (challengeManager == null)
            {
                Debug.LogError("No se pudo encontrar un ChallengeManager en la escena.");
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Detectar si el objeto tiene la etiqueta "Throwable"
        if (other.CompareTag("Throwable"))
        {
            Debug.Log("Objeto encestado en " + gameObject.name);

            // Notificar al ChallengeManager que un objeto ha sido encestado
            challengeManager.ObjectScored();
        }
    }
}

