using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyPrefab.GetComponent<EnemyController>().isTriggered = true;
            transform.position = enemyPrefab.transform.position;
            Transform State = transform;

            enemyPrefab.transform.position = State.position;
        }
    }
}
