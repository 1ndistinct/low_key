using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    private GameObject PlayerPosition;
    public Transform TriggerMarker;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        PlayerPosition = GameObject.Find("Mr.AlienMain");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Anim.SetTrigger("PlayerInRange");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.currentHealth = 0;
    }
}
