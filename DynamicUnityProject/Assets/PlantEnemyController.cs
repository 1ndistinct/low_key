using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemyController : MonoBehaviour
{
    public GameObject PoolerLocation;
    public float ShotTime, BurstFiretime;
    private float time;
    private Transform PlayerPosition;
    public int EnemyOrientation = 1; //1 is right, -1 is left
    // Start is called before the first frame update
    void Start()
    {
        time = ShotTime;
        PlayerPosition = GameObject.Find("Mr.AlienMain").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPosition.position.x > transform.position.x)
        {
            print("right");
           
            if (EnemyOrientation != 1)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                EnemyOrientation = 1;
            }
            
        }
        else
        {
            print("Left");
            
            if (EnemyOrientation == 1)
            {
                EnemyOrientation = -1;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject Proj = PoolerLocation.GetComponent<ObjectPooler>().GetPooledObject();
            Proj.SetActive(true);
        }

        if (ShotTime <= 0)
        {
            GameObject Proj = PoolerLocation.GetComponent<ObjectPooler>().GetPooledObject();
            Proj.SetActive(true);
            ShotTime = time;
        }
        else
        {
            ShotTime -= Time.deltaTime;
        }
    }
}
