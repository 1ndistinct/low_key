using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityStandardAssets._2D;

public class EnemyDestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    public Transform Center;
    private EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        topBound = Center.transform.position.x + 10;
        lowerBound = Center.transform.position.x - 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        topBound = Center.position.x + 30;
        lowerBound = Center.position.x - 30;
        if (transform.position.x > topBound)
        {
            // Instead of destroying the projectile when it leaves the screen
            gameObject.SetActive(false);
            transform.position = Center.position + new Vector3(0, 0.7f, 0);
            // Just deactivate it
            //gameObject.SetActive(false);

        }
        else if (transform.position.x < lowerBound)
        {

            gameObject.SetActive(false);
            transform.position = Center.position + new Vector3(0, 0.7f, 0);
            //gameObject.SetActive(false);
        }

    }
}
