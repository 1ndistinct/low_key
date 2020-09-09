using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    Transform player;
    public float targetTime = 0.5f;

    void timerEnded()
    {
        gameObject.SetActive(false);
        targetTime = 0.5f;
    }



// Start is called before the first frame update
void Start()
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
}
