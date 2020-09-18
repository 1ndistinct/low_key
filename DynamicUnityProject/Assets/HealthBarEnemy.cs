using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : MonoBehaviour
{
    Vector3 localScale;
    float perc;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        perc = EnemyController.Health/EnemyController.MaxHealth;
        localScale.x = perc* 1.275984f;
        transform.localScale = localScale;

    }
}
