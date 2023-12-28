using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    float dirX;
    float speed = 5f;

    bool movingRight = true;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (transform.position.x > 350f)
        {
            movingRight = false;
        }
        else if (transform.position.x < 220f)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            FlipSprite(false);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            FlipSprite(true);
        }
    }

    void FlipSprite(bool flipX)
    {
        spriteRenderer.flipX = flipX;
    }
}
