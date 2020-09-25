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

}
