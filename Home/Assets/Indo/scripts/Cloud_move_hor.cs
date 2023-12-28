using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_move_hor : MonoBehaviour
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
        if (transform.position.x > 700f)
        {
            movingRight = false;
        }
        else if (transform.position.x < 600f)
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
