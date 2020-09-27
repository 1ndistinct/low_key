using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed =40;
    private bool mf;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mf = PlayerController1.right;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mf)
            rb.AddForce(Vector2.right * 80 , ForceMode2D.Impulse);
        else if(!mf)
            rb.AddForce(Vector2.left * 80 , ForceMode2D.Impulse);
    }
}
