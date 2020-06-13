using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float correrVel = 8.5f;
    public float playerSpeed = 3.5f;
    public Sound jumpSound;
    public Sound lostSound;
    public Sound winSound;
    public Sound tookSound;
    public int muertoCount = 0;

    public LayerMask capaSuelo;
    public Transform checkSuelo;

    //private float horizontalInput;

    private Animator myAnimator;

    private SpriteRenderer mySpriteRender;

    private Rigidbody2D myRigidbody2D;

    private GameManager gameManager;
 
    

    //-----------------------------------

    bool correr;
    bool enSuelo;
    bool dobleSalto;
    bool Muerto;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        //escalaPrincipal = transform.localScale;
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            correr = true;
        }
        else
        {
            correr = false;
        }

        if (correr)
        {
            horizontal = Input.GetAxis("Horizontal") * correrVel;
        }else 
        {
            horizontal = Input.GetAxis("Horizontal") * playerSpeed;
        }
         
        myRigidbody2D.velocity = new Vector2(horizontal, myRigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Muerto == false)
        {
            if (enSuelo)
            {
                AudioManager.Instance.PlaySound(jumpSound);
                myRigidbody2D.AddForce(Vector2.up * playerJumpForce);
                myAnimator.SetTrigger("Saltar");
            }else if (dobleSalto)
            {
                AudioManager.Instance.PlaySound(jumpSound);
                myRigidbody2D.velocity = Vector2.zero;
                myRigidbody2D.AddForce(Vector2.up * playerJumpForce);
                myAnimator.SetTrigger("Saltar");
                dobleSalto = false;
            }
            
        }

        if (myRigidbody2D.velocity.x < 0f)
        {
            mySpriteRender.flipX = true;
        }
        else if (myRigidbody2D.velocity.x > 0f)
        {
            mySpriteRender.flipX = false;
        }


        //Animaciones

        if(horizontal != 0 )
        {
            myAnimator.SetBool("Andar", true);
        }
        else
        {
            myAnimator.SetBool("Andar", false);
        }
        myAnimator.SetBool("Correr", correr);
        myAnimator.SetBool("enSuelo", enSuelo);
        myAnimator.SetBool("Muerto", Muerto);

        //DOBLE SALTO

        if (enSuelo)
            dobleSalto = true;
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(checkSuelo.position, 01f,capaSuelo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(GameTag.Mob))
        {
            if (muertoCount < 1)
            {
                AudioManager.Instance.PlaySound(lostSound);
                muertoCount++;
            }
            Muerto = true;
            GameManager.Instance.GameOver();
        }
        if (collision.CompareTag(GameTag.DeadZone))
        {
            if (muertoCount < 1)
            {
                AudioManager.Instance.PlaySound(lostSound);
                muertoCount++;
            }
            
            Muerto = true;
            GameManager.Instance.GameOver();
        }else if (collision.CompareTag(GameTag.Objetivo))
        {
            AudioManager.Instance.PlaySound(tookSound);
            Destroy(collision.gameObject);
            gameManager.AddScore();
        }
         
    }

}

   
       

   

 