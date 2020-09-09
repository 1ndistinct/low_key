using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    public float dashDistance;
    public Vector2 dashLocal;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public float moveSpeed = 0;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public GameObject projectilePrefab;

    private float horizontalInput;
    private float speed = 10.0f;
    private float xRange = 20;
    public static bool right = true;
    public int playerOrientation; //1--> Right facing  -1 --> Left Facing
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        //playerAnim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Restricts movement on x axis past this point
        if (transform.position.x < -xRange)
            transform.position = new Vector2(-xRange, transform.position.y);

        if (transform.position.x > xRange)
            transform.position = new Vector2(xRange, transform.position.y);
        //

        // Player movement left to right
        horizontalInput = Input.GetAxis("Horizontal");
        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && !gameOver)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput*20);
        }
        //
        // Player movement left to right
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        }
        //
        //Condition for which way to shoot
        if (horizontalInput < -0.1)
        {
            if (right)
            {
                flip();
                right = false;
                playerOrientation = -1;
            }
        
        }
        else if (horizontalInput > 0.1)
        {
            if (!right)
            {
                flip();
                right = true;
                playerOrientation = 1;
            }
           
            
        }
        //

       //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            /*playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);*/
        }
        //
        
        //Shoot
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            // No longer necessary to Instantiate prefabs
             Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // Get an object object from the pool
/*            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
                
            }*/
        }
        //
    }

    public Vector2 Dash()
    {
        Vector2 finalLocal = transform.position;
        finalLocal.x += playerOrientation * dashDistance;
        return finalLocal;
    }

    private void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if player is on ground to jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
           // dirtParticle.Play();
        }
        //
        //Collision with monster
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            /*playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);*/
        }
        //
    }
}
