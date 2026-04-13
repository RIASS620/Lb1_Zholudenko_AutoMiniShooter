using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    private int currentHealth;

    // Подія для сповіщення інших систем
    public event Action OnDie;

    private void OnEnable()
    {
        currentHealth = maxHealth;

        // Якщо це гравець, оновлюємо інтерфейс відразу при появі
        if (CompareTag("Player") && UIManager.Instance != null)
        {
            UIManager.Instance.UpdateHP(currentHealth);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Якщо це гравець, оновлюємо цифри здоров'я на екрані
        if (CompareTag("Player") && UIManager.Instance != null)
        {
            UIManager.Instance.UpdateHP(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDie?.Invoke();

        // ЛОГІКА ДЛЯ ГРАВЦЯ
        if (CompareTag("Player"))
        {
            if (UIManager.Instance != null && GameManager.Instance != null)
            {
                UIManager.Instance.ShowGameOver(GameManager.Instance.Score);
            }
        }
        // ЛОГІКА ДЛЯ ВОРОГА
        else if (CompareTag("Enemy"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(100); // Додаємо 100 очок за кожного збитого ворога
            }
        }

        // ПОВЕРНЕННЯ В ПУЛ АБО ВИМКНЕННЯ
        PoolMember poolMember = GetComponent<PoolMember>();
        if (poolMember != null)
        {
            poolMember.ReturnToPool();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}