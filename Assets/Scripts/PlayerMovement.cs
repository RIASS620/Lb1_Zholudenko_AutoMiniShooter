using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float xLimit = 8f; // Обмеження екрана по горизонталі

    void Update()
    {
        // Використовуємо нову систему вводу (Unity 6)
        float moveInput = 0;
        if (UnityEngine.InputSystem.Keyboard.current != null)
        {
            if (UnityEngine.InputSystem.Keyboard.current.leftArrowKey.isPressed ||
                UnityEngine.InputSystem.Keyboard.current.aKey.isPressed)
                moveInput = -1;
            else if (UnityEngine.InputSystem.Keyboard.current.rightArrowKey.isPressed ||
                     UnityEngine.InputSystem.Keyboard.current.dKey.isPressed)
                moveInput = 1;
        }

        // Розраховуємо нову позицію
        Vector3 newPosition = transform.position + Vector3.right * moveInput * speed * Time.deltaTime;

        // Обмежуємо рух, щоб корабель не вилітав за екран
        newPosition.x = Mathf.Clamp(newPosition.x, -xLimit, xLimit);

        transform.position = newPosition;
    }
}