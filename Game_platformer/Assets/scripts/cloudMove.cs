using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove : MonoBehaviour
{
    float dirY;
    float speed = 5f;

    bool movingUp = true;

    // Update is called once per frame 
    void Update()
    {
        if (transform.position.y > 70f)
        {
            movingUp = false;
        }
        else if (transform.position.y < -10f)
        {
            movingUp = true;
        }

        if (movingUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
