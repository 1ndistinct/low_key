using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformMove : MonoBehaviour
{

    public Transform position1, position2;
    public float speed;
    private Transform nextPosition;
    private Vector2 desiredPosition;
    private Vector3 moveDelta;
    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = position1.position;
        nextPosition = position2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == position2.position)
        {
            nextPosition = position1;
        }
        if (transform.position == position1.position)
        {
            nextPosition = position2;
        }
        desiredPosition = Vector2.MoveTowards(transform.position, nextPosition.position, speed * Time.deltaTime);
        moveDelta = new Vector3(desiredPosition.x,desiredPosition.y,0f) - transform.position;
        transform.position = desiredPosition; 



    }

    private void LateUpdate()
    {
        if (player) {
            player.transform.position = new Vector3(player.position.x, player.position.y) + moveDelta;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Rigidbody2D>();

        }
    }
    private void  OnTriggerExit2D(Collider2D other)
    {
        //Remove reference
        if (other.gameObject.CompareTag("Player"))
            player = null;
    }


}
