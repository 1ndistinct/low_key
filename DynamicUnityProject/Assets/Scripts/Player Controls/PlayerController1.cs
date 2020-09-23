using Platformer.Mechanics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    public float xInput, yInput, xForce,dForce;
    Vector2 dashForce,force;
    public float jumpForce;
    public float gravityModifier;
    private float gravity;
    public bool isOnGround = true;
    public float forceMultiplier;
    float t = 1, MaxGravity = 50;
    public GameObject gameOverOverlay;
    
    //
    private Rigidbody2D rb;
    //
 


    //User Variables
    public static float maxHealth = 10;
    public static float maxEnergy = 1;
    
    public HealthBar healthBar;
    public EnergyBar energyBar;
    public GameObject mainCamera;
    private Animator playerAnim,cameraAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public GameObject projectilePrefab;
    public GameObject meleePrefab;
  
    public static bool right ;
    public int playerOrientation; //1--> Right facing  -1 --> Left Facing
    // Start is called before the first frame update
    public static bool doActive = true;

   
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        right = true;
        //GameObject.DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody2D>();
        cameraAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        playerAnim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();
        GameManager.currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        GameManager.currentEnergy = maxEnergy;
        energyBar.setMaxEnergy(maxEnergy);
        gravity = rb.gravityScale;

    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.currentHealth <= 0)
            GameOver();

        rb.gravityScale =gravity* gravityModifier;
        energyBar.setEnergy(GameManager.currentEnergy);
        healthBar.setHealth(GameManager.currentHealth);


        if (isOnGround)
        {
            gravityModifier = 1;
        }
        else
        {
            if (gravityModifier <= MaxGravity)
            {
                gravityModifier += 1f;
            }
        }
        /*//Restricts movement on x axis past this point
        if (transform.position.x < -mainCamera.transform.position.x)
            transform.position = new Vector2(-xRange, transform.position.y);

        if (transform.position.x > mainCamera.transform.position.x)
            transform.position = new Vector2(mainCamera.transform.position.x, transform.position.y);*/
        //
        getAction();

        GameManager.PlayerCoords = gameObject.transform;
      


    }

    private void getAction() {
        
        //if (!isOnGround)
            //gravityModifier = 20;
        t -= Time.deltaTime;
        if (t <= 0)
        {
            GameManager.AddEnergy(0.1f);
/*            if (!isOnGround)
                gravityModifier += 10;*/
            t = 1f;
        }
        
        if (doActive)
        {
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
            xForce = xInput * GameManager.moveSpeed * 60000 * Time.deltaTime*forceMultiplier;
            if (right)
                dForce = GameManager.moveSpeed * 60000 * Time.deltaTime * 25*forceMultiplier;
            else
                dForce = -1 * GameManager.moveSpeed * 60000 * Time.deltaTime * 25*forceMultiplier;
           
            
            force = new Vector2(xForce, 0);
            dashForce = new Vector2(dForce, 0);

            //Dash
            if (Input.GetButtonDown("Dash") && !GameManager.gameOver)
            {
                if (GameManager.currentEnergy > 0.3)
                {
                    force.x += dashForce.x;
                    UseEnergy(0.3f);
                }
            }
            //
            //Jump
            if (Input.GetButtonDown("Jump") && isOnGround && !GameManager.gameOver)
            {
                force.y += jumpForce * 1000*forceMultiplier;
                isOnGround = false;
                /*playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);*/
            }
            //

            //Shoot
            if (Input.GetButtonDown("Projectile") && !GameManager.gameOver)
            {

                if (GameManager.currentEnergy > 0.2)
                {
                    Instantiate(projectilePrefab, transform.position + new Vector3(xInput * 2, 0, 0), projectilePrefab.transform.rotation);
                    UseEnergy(0.2f);
                }
                // No longer necessary to Instantiate prefabs


                // Get an object object from the pool
                /*            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
                            if (pooledProjectile != null)
                            {
                                pooledProjectile.SetActive(true); // activate it
                                pooledProjectile.transform.position = transform.position; // position it at player

                            }*/
            }
            //
            else if (Input.GetButtonDown("Melee") && !GameManager.gameOver)
            {
                if (GameManager.currentEnergy > 0.1)
                {
                    meleePrefab.SetActive(true);
                    UseEnergy(0.1f);
                }

                // No longer necessary to Instantiate prefabs

            }


            //Move
            if (!GameManager.gameOver)
                rb.AddForce(force,ForceMode2D.Force);
            



            //Condition for which way to shoot
            if (xInput < -0.1)
            {
                if (right)
                {
                    flip();
                    right = false;
                    playerOrientation = -1;
                }

            }
            else if (xInput > 0.1)
            {
                if (!right)
                {
                    flip();
                    right = true;
                    playerOrientation = 1;
                }


            }
        }
        //

    }


    void UseEnergy(float x)
    {
        
        if (GameManager.currentEnergy <= 0)
            GameManager.currentEnergy = 0;
        else
            GameManager.currentEnergy -= x;
        energyBar.setEnergy(GameManager.currentEnergy);
    }



    private void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if player is on ground to jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("PORTAL"))
        {
            isOnGround = false;

        }
        if (collision.gameObject.CompareTag("Far View"))
        {
            cameraAnim.SetTrigger("ZoomIn");
            cameraAnim.ResetTrigger("ZoomOut");
        }
        if (collision.gameObject.CompareTag("Coin Pickup"))
        {
            collision.gameObject.SetActive(false);
            GameManager.Coins += 1;
        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isOnGround = true;
            print("on");
           // gameObject.transform.parent = collision.gameObject.transform;
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
           
            isOnGround = true;
            
            // gameObject.transform.parent = collision.gameObject.transform;
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            playerAnim.SetTrigger("DamageTaken");
        }
        if (collision.gameObject.CompareTag("ImmediateDeath"))
        {
            playerAnim.SetTrigger("DamageTaken");
            GameOver();
            Thread.Sleep(10);
            gameObject.SetActive(false);

        }




    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("MovingPlatform"))
            isOnGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Far View"))
        {
            cameraAnim.SetTrigger("ZoomOut");
            cameraAnim.ResetTrigger("ZoomIn");
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;

        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            //gameObject.transform.parent = null;
            isOnGround = false;
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            
            isOnGround = false;

        }


    }

    public void PlayerTakesDamage(float Damage, float stunDuration)
    {
        GameManager.currentHealth -= Damage;
        playerAnim.SetTrigger("DamageTaken");
        StartCoroutine(PlayerStunned(stunDuration));
    }
    IEnumerator PlayerStunned(float stunDuration)
    {
        doActive = false;
        yield return new WaitForSeconds(stunDuration);
        doActive = true;
    }
    private void GameOver() 
    {
        GameManager.gameOver = true;
        gameOverOverlay.SetActive(true);
        GameManager.currentHealth = 0f;
        /*playerAnim.SetBool("Death_b", true);
           playerAnim.SetInteger("DeathType_int", 1);
           explosionParticle.Play();
           dirtParticle.Stop();
           playerAudio.PlayOneShot(crashSound, 1.0f);*/
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("MovingPlatform")) //|| collision.gameObject.CompareTag("Ground")
        {
            
            Vector2 dir = collision.contacts[0].point - new Vector2(transform.position.x, transform.position.y);
            // We then get the opposite (-Vector3) and normalize it
            dir = dir.normalized;
            print(dir.x+":"+dir.y);
            if ((dir.x <-0.4 || dir.x > 0.4) && dir.y > -1)
            {
                print("Force");
                isOnGround = false;
                rb.AddForce(Vector2.down * rb.gravityScale*50, ForceMode2D.Force);
            }
            
        }
    }




}
