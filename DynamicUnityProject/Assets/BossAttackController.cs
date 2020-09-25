using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    private GameObject PlayerPosition;
    public Transform TriggerMarker;
    private Animator Anim;
    //Variables
    public static float MaxHealth = 1f;
    public static float Health = 1f;
    public float EnemyHealth = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        PlayerPosition = GameObject.Find("Mr.AlienMain");
    }

    // Update is called once per frame
    void Update()
    {
        Health = EnemyHealth;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            if (EnemyHealth - 0.1f <= 0)
            {
                gameObject.SetActive(false);
                EnemyHealth = 0f;
                
                GameManager.AddEnergy(0.25f);
            }
            else
            {
                EnemyHealth -= 0.1f;
            }
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("melee"))
        {

            if (EnemyHealth - 0.1f <= 0)
            {
                EnemyHealth = 0;
                gameObject.SetActive(false);
               
                GameManager.AddEnergy(0.25f);

            }
            else
                EnemyHealth -= 0.1f;

        }
        if (other.CompareTag("Player"))
        {
            Anim.SetTrigger("PlayerInRange");
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.currentHealth = 0;
    }
}
