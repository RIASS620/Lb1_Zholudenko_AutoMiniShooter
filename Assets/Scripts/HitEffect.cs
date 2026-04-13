using UnityEngine;
using System.Collections;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float duration = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Викликайте цей метод з Health.cs при отриманні шкоди
    public void PlayEffect()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = originalColor;
    }
}