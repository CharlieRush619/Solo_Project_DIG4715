using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 






public class HorizontalMovement : Character
{
    public AudioSource collectSound;
    public AudioSource hitSound;
    public float speed;
    public float distanceToCollider;
    public LayerMask collisionLayer;
    private float horizontalInput;
    public Animator animator;

    public Text MyscoreText;
    private int ScoreNum;

    

    protected override void Initializtion()
    {
        base.Initializtion();
    }

    // Update is called once per frame 
    void Update()
    {
animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));


        if (Input.GetAxis("Horizontal") != 0)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else
        {
            horizontalInput = 0;
        }
    }

    

   
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("MyApple"))
    {
       collectSound.Play();
        ScoreNum +=1;
        Destroy(other.gameObject);
        MyscoreText.text = "Score " + ScoreNum;
        
    }

    if (other.gameObject.CompareTag("MyAcorn"))
    {
          hitSound.Play();
          Destroy(other.gameObject);
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}




    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);
        if(horizontalInput > 0 && character.isFacingLeft)
        {
            character.isFacingLeft = false;
            Flip();
        }
        if(horizontalInput < 0 && !character.isFacingLeft)
        {
            character.isFacingLeft = true;
            Flip();
        }
        SpeedModifier();
    }

    private void SpeedModifier()
    {
        if((rb.velocity.x > 0 && CollisionCheck(Vector2.right, distanceToCollider, collisionLayer)) || (rb.velocity.x < 0 && CollisionCheck(Vector2.left, distanceToCollider, collisionLayer)))
        {
            rb.velocity = new Vector2(.01f, rb.velocity.y);
        }
    }
}