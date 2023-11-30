using UnityEngine;

public class FlighTest : MonoBehaviour
{
    public float flightSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // ��������� ����������
    }

    void Update()
    {
        // �������� ���� �� ������
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ��������� ������ ����������� � ���������� ��������
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * flightSpeed;
        rb.velocity = movement;
    }
}
