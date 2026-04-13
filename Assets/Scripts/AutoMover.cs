using UnityEngine;

public class AutoMover : MonoBehaviour
{
    [SerializeField] private Vector2 direction = Vector2.up;
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        // Рух у заданому напрямку з урахуванням часу кадру
        transform.Translate(direction.normalized * (speed * Time.deltaTime));
    }

    // Дозволяє змінювати напрямок динамічно (наприклад, для самонавідних ракет у майбутньому)
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}