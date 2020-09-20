using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPressedRestart : MonoBehaviour
{
    public string scene;
    public void Respawn()
    {
        
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        GameManager.gameOver = false;
    }
}
