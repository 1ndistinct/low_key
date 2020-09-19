using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDestroyer : MonoBehaviour
{
    private Rigidbody2D rb;
    private float destroyTimer;
    public float ProjSpeed, FireRate;
    private GameObject Shooter;

    private Transform firingLocal, destroyLocal;
    // Start is called before the first frame update
    void Start()
    {
        Shooter = GameObject.Find("ProjectileTrap");
        firingLocal = Shooter.GetComponent<ProjectileTrapShoot>().firingLocal;
        destroyLocal = Shooter.GetComponent<ProjectileTrapShoot>().destroyLocal;
        destroyTimer = Mathf.Abs(firingLocal.position.x - destroyLocal.position.x) / ProjSpeed;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-ProjSpeed, 0);
        Destroy(this.gameObject, destroyTimer);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 dir = collision.contacts[0].point - new Vector2(transform.position.x, transform.position.y);
            // We then get the opposite (-Vector3) and normalize it
            dir = dir.normalized;
            Rigidbody2D rbb = collision.gameObject.GetComponent<Rigidbody2D>();
            PlayerController1.doActive = false;
            rbb.AddForce(dir * 600, ForceMode2D.Impulse);
            GameManager.TakeDamage(0.2f * PlayerController1.maxHealth);
            
            PlayerController1.doActive = true;
            Destroy(gameObject);
            /*playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);*/
        }
    }

}
