using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Це дозволяє іншим скриптам бачити UIManager
    public static UIManager Instance;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private void Awake()
    {
        // Перевіряємо, чи ми єдині в сцені
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScore(int currentScore)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;
    }

    public void UpdateHP(int currentHP)
    {
        if (hpText != null)
            hpText.text = "HP: " + currentHP;
    }

    public void ShowGameOver(int finalScore)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            finalScoreText.text = "Final Score: " + finalScore;
            Time.timeScale = 0f; // Зупиняємо час у грі
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1f; // Повертаємо час у норму
    }
}