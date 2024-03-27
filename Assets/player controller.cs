using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 8f;
    public Rigidbody2D rb;

    public float moveUp = 9f; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w")){
            //print("jump");
            rb.AddForce(Vector2.up * moveUp, ForceMode2D.Impulse);
        }
        //animator.Play();
        float input = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * moveSpeed * input);
    }
}
