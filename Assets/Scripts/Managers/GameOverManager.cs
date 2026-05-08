using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("Listen to event channels")]
    public VoidEventChannel onPlayerDeath;

    private void Start()
    {
        Canvas gameOverCanvas = GameObject.Find("GAMEOVER").GetComponent<Canvas>();
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false;
        }
    }

    private void OnEnable()
    {
        onPlayerDeath.OnEventRaised += OnGameOver;
    }

    public void OnGameOver()
    {
        Canvas gameOverCanvas = GameObject.Find("GAMEOVER").GetComponent<Canvas>();
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = true;
            Time.timeScale = 0f;
        }
    }

    private void OnDisable()
    {
        onPlayerDeath.OnEventRaised -= OnGameOver;
    }
}