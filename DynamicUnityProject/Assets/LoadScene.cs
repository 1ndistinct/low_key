using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadScene : MonoBehaviour
{
    public int scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.UnloadSceneAsync("SpawnScene");
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }
}
