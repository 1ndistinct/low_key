using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneOnEnviroLoad : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rbPlayer;
    public Transform SpawnLocal;
    private string scene = "PlayerNeverUnload";
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Mr.AlienMain");
        print(player);
        player.transform.Translate(SpawnLocal.position);
        /*rbPlayer = player.GetComponent<Rigidbody2D>();
        rbPlayer.MovePosition(new Vector2(SpawnLocal.position.x,SpawnLocal.position.y));*/
    }

}
