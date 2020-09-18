using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnviroLoad : MonoBehaviour
{
    public Scene PlayerScene;
    private string scene = "PlayerNeverUnload";
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerScene.isLoaded)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
        
    }

}
