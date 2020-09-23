using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiControls : MonoBehaviour
{
    
    private bool OptionsScreenOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OptionsScreenOn)
            {
                SceneManager.UnloadSceneAsync("InGameMenu");
                OptionsScreenOn = false;
            }
            else
            {
                SceneManager.LoadScene("InGameMenu",LoadSceneMode.Additive);
                OptionsScreenOn = true;
            }

            
        }
    }

}
