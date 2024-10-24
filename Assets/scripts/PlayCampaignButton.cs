using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCampaignButton : MonoBehaviour
{
    public void ChangeScene()
    {
        // Cambia a la escena llamada "tierra"
        SceneManager.LoadScene("tierra");
    }
}