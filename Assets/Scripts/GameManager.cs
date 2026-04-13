using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public int Score => score;

    private void Awake()
    {
        Instance = this;

        // Зупиняємо час у грі одразу при завантаженні сцени
        Time.timeScale = 0f;
    }

    // Цей метод ми призначимо на кнопку "СТАРТ"
    public void StartGame()
    {
        // Запускаємо час, і все починає рухатися
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UIManager.Instance.UpdateScore(score);
    }

    public void RestartGame()
    {
        // Важливо: повертаємо час у норму перед перезавантаженням, 
        // щоб наступна сцена не зависла на старті (хоча ми скидаємо його в Awake)
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}