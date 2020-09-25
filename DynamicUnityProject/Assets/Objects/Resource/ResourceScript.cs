using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public int hitsLeft;
    Animator anim;
    public GameObject resources;
    private void Start()
    {
        
        anim = gameObject.GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("melee") || collision.gameObject.CompareTag("projectile"))
        {
            if (collision.gameObject.CompareTag("projectile"))
                Destroy(collision.gameObject);
            anim.SetTrigger("OnHit");
            hitsLeft--;
            if (hitsLeft<=0)
            {
                resources.SetActive(true);
                gameObject.SetActive(false);
                
            }
        }
    }
}
