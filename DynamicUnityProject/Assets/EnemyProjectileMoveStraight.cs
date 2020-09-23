using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyProjectileMoveStraight : MonoBehaviour
{
    
    public float ProjectileSpeed, ProjectileDamage, stunDuration;
    private int EnemyOrientation;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemyOrientation = GameObject.Find("EnemyPlant").GetComponent<PlantEnemyController>().EnemyOrientation;

        //Chnages Axes
        if (EnemyOrientation == -1)
        {
            transform.SetPositionAndRotation(transform.position, new Quaternion(0, 180, 0, 0));
        }
        else
        {
            transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 0));
        }
        rb.velocity = new Vector2(1, 0) * ProjectileSpeed * EnemyOrientation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            
            collision.gameObject.GetComponent<PlayerController1>().PlayerTakesDamage(ProjectileDamage, stunDuration);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(10000*EnemyOrientation, 0));
            transform.position = GetComponent<EnemyDestroyOutOfBound>().Center.position + new Vector3(0, 0.7f, 0);
        }
    }
}
