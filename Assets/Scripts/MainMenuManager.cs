using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}