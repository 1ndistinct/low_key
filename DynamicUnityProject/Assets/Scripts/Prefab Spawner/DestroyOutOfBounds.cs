using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    public Transform mainCamera;
    private EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera2DFollow.pos;
        topBound = mainCamera.transform.position.x + 10;
        lowerBound = mainCamera.transform.position.x - 10;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera = Camera2DFollow.pos;
        topBound = mainCamera.position.x + 30;
        lowerBound = mainCamera.position.x - 30;
        if (transform.position.x > topBound)
        {
            // Instead of destroying the projectile when it leaves the screen
            Destroy(gameObject);

            // Just deactivate it
            //gameObject.SetActive(false);

        }
        else if (transform.position.x < lowerBound)
        {
            
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<EnemyController>().EnemyHealth - 0.2f <= 0)
            {
                other.gameObject.GetComponent<EnemyController>().EnemyHealth = 0;
                other.gameObject.SetActive(false);
                GameManager.AddEnergy(0.25f);
            }
            else
            {
                other.gameObject.GetComponent<EnemyController>().EnemyHealth -= 0.2f;
            }
            Destroy(gameObject);
        }
    }
}
