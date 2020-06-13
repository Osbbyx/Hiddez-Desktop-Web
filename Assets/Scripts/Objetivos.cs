using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivos : MonoBehaviour
{
    public float horizontalSpeed = 3f;
    private Rigidbody2D plataformbody2d;

    private Vector2 pointA;
    private Vector2 pointB;
    private bool movingRight;
    private SpriteRenderer mySpriteRender;
    private Animator myAnimator;
    bool Atk;

    int cant = 0;
    public float a = 1f;
    public float b = -1f;

    void Start()
    {
        plataformbody2d = GetComponent<Rigidbody2D>();
        pointA = new Vector2(b, plataformbody2d.position.y);
        pointB = new Vector2(a, plataformbody2d.position.y);
        mySpriteRender = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();

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
            mySpriteRender.flipX = true;
        }
        else if (transform.position.x <= pointA.x)
        {
            movingRight = true;
            mySpriteRender.flipX = false;
        }
    }

    void Update()
    {
        Move();
        myAnimator.SetBool("Atk", Atk);
        myAnimator.SetInteger("cant", cant);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.Player))
        {
            Atk = true;
            cant++;
        }
    }
}
