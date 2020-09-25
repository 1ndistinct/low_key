using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeAnimationTrigger : MonoBehaviour
{
    public GameObject rope;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = rope.GetComponent<Animator>();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            animator.SetBool("PlayerMounted",true);
            collision.gameObject.transform.position = transform.position;
            collision.gameObject.GetComponent<PlayerController1>().isOnGround = true;
        }
    }
}
