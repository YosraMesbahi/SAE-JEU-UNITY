using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("Listen to event channels")]
    public VoidEventChannel onPlayerDeath;

    [Header("Buttons")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    private void Start()
    {
        // Au démarrage, cacher le GameOver
        Canvas gameOverCanvas = GameObject.Find("GAMEOVER").GetComponent<Canvas>();
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false;
        }

        // Assigner les boutons
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartLevel);
        }
        
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(GoToMainMenu);
        }
    }

    private void OnEnable()
    {
        // Écouter l'événement "joueur meurt"
        onPlayerDeath.OnEventRaised += OnGameOver;
    }

    public void OnGameOver()
    {
        // Quand le joueur meurt:
        Canvas gameOverCanvas = GameObject.Find("GAMEOVER").GetComponent<Canvas>();
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = true;  // Afficher le GameOver
            Time.timeScale = 0f;            // Mettre en pause
        }
    }
    private void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDisable()
    {
        // Arrêter d'écouter
        onPlayerDeath.OnEventRaised -= OnGameOver;
    }
}