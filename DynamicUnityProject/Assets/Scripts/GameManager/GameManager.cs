using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static Transform PlayerCoords;
    public static GameManager Instance { get { return _instance; } }

    public static int Coins = 0;
    public static float currentHealth, currentEnergy ;
    public static float moveSpeed = 1f;
    public static float shield = 0.2f;
    public static bool gameOver = false;

    public static void AddEnergy(float x)
    {
        float energy = x;
        if (GameManager.currentEnergy + energy >= 1)
        {
            GameManager.currentEnergy = 1;
            energy = GameManager.currentEnergy + energy - 1;
            if (GameManager.shield + energy > 0.3f)
                GameManager.shield = 0.3f;
            else
                GameManager.shield += energy;
        }
        else
            GameManager.currentEnergy += energy;

        
    }
    public static void TakeDamage(float x)
    {
        float dmg = x;
        if (GameManager.shield > 0)
        {
            if (dmg - GameManager.shield < 0)
            {
                GameManager.shield -= dmg;
                dmg = 0;
            }
            else
            {
                GameManager.shield = 0;
                dmg = dmg - GameManager.shield;
            }
        }
        if (GameManager.currentHealth - dmg <= 0)
            GameManager.currentHealth = 0;
        else
            GameManager.currentHealth -= dmg;



    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
/*    void Update()
    {

    }*/

}
