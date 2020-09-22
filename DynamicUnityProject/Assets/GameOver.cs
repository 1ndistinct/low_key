using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void Reload() 
    {
        GameManager.currentHealth = PlayerController1.maxHealth;
        GameManager.currentEnergy = PlayerController1.maxEnergy;
        SceneManager.LoadScene(1);
        GameManager.gameOver = false;
       
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
