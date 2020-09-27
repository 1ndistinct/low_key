using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class ProjectileAttack : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    public Transform mainCamera;
  
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Mr.AlienMain").GetComponent<Transform>();
        topBound = mainCamera.position.x + 7;
        lowerBound = mainCamera.position.x - 7;
    }

    // Update is called once per frame
    void Update()
    {
        
        topBound = mainCamera.position.x + 10;
        lowerBound = mainCamera.position.x - 10;
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
