using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float horizontalSpeed = 3f;
    private Rigidbody2D plataformbody2d;

    private Vector2 pointA;
    private Vector2 pointB;
    private bool movingRight;

    public float a = 1f;
    public float b = -1f;

    void Start()
    {
        plataformbody2d = GetComponent<Rigidbody2D>();

        pointA = new Vector2(b, plataformbody2d.position.y);
        pointB = new Vector2(a, plataformbody2d.position.y);

    }

    private void Move()
    {
        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB, horizontalSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA, horizontalSpeed * Time.deltaTime);
        }
        if (transform.position.x >= pointB.x)
        {
            movingRight = false;
        }
        else if (transform.position.x <= pointA.x)
        {
            movingRight = true;
        }
    }

    void Update()
    {
        Move();
    }


}
