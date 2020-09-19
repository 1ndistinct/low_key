using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    Transform player;
    public float targetTime = 0.5f;
    public float MeleeDamage;
    private EnemyController enemyController;
    void timerEnded()
    {
        gameObject.SetActive(false);
        targetTime = 0.5f;
    }



    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        
        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            enemyController = gameObject.GetComponent<EnemyController>();
            enemyController.EnemyHealth -= MeleeDamage;
        }
    }
}
