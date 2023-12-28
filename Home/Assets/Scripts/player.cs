using UnityEngine;

public class player : MonoBehaviour
{

    public float speed = 200f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * 300000);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals ("Moving_platform"))
        {
            this.transform.parent = collision.transform;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Moving_platform"))
        {
            this.transform.parent = null;
        }
    }
}

