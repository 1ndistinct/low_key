using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnSceneSpecific : MonoBehaviour
{
    public GameObject playerToMove;
    // Start is called before the first frame update
    void Start()
    {
       /* playerToMove = GameObject.FindGameObjectWithTag("Player");
        SceneManager.MoveGameObjectToScene(playerToMove, SceneManager.GetActiveScene());*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
