using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHONDA : MonoBehaviour
{
    Animator animator;
    public float moveSpeed;
    public Rigidbody2D rb;
    public float maxSpeed = 1;

    public float moveUp; 
    // Start is called before the first frame update
   void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded() )
        {
            animator.SetTrigger("Jump");
            //print("jump");
            rb.AddForce(Vector2.up * moveUp, ForceMode2D.Impulse);
        }
        //animator.Play();
        float input = Input.GetAxis("Horizontal2");
        print(input);
        if(rb.velocity.magnitude < maxSpeed){
            rb.AddForce(Vector2.right * moveSpeed * input);
        }

        /*
        if(Input.GetKeyDown("e")){
            animator.SetTrigger("punch1");
        }

        if(Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isWalkin", true);
        }
        else{
            animator.SetBool("isWalkin", false);

        }
        */

    }
    private bool isGrounded()
    {
        Vector2 center = transform.position - transform.up * 0.5f;
        float radius = 3f;

        if(Physics2D.OverlapCircle(center, radius, 1<<6)){
            print("isgrounded");
        }
        else{
            print("not");
        }

        return Physics2D.OverlapCircle(center, radius, 1<<6);
    }

}
