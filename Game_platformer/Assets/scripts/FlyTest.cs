using UnityEngine;

public class FlighTest : MonoBehaviour
{
    public float flightSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Отключаем гравитацию
    }

    void Update()
    {
        // Получаем ввод от клавиш
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Вычисляем вектор направления и перемещаем персонаж
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * flightSpeed;
        rb.velocity = movement;
    }
}
