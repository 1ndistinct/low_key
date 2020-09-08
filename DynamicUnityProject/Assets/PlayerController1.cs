using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    public float dashForce;
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
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        //
        //Condition for which way to shoot
        if (horizontalInput < -0.1)
        {
            if (right)
                right = false;
        }
        else if (horizontalInput > 0.1)
        {
            if (!right)
                right = true;
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
        //Dash
        else if (Input.GetKeyDown(KeyCode.LeftShift) && !gameOver)
        {
            if (horizontalInput < 0 )
                rb.AddForce(Vector2.right * dashForce  * -1, ForceMode2D.Impulse);
            else
                rb.AddForce(Vector2.right * dashForce * 1, ForceMode2D.Impulse);
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
            /*GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
                
            }*/
        }
        //
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
