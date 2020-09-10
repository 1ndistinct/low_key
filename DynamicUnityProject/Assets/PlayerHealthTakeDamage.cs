using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthTakeDamage : MonoBehaviour
{
    
    public float maxHP;
    public float currentHealth;
    Transform HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = transform;
        maxHP = 100;
        currentHealth = maxHP;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Function used to check--Debugger
        if (Input.GetKeyDown(KeyCode.Q))
        {

            transform.localScale.Set(1f,1f,1f);
            print(transform.localScale);
        }
    }
}
