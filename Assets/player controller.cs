using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    Animator animator;
    public float moveSpeed;
    public Rigidbody2D rb;
    public float maxSpeed = 1;
    public float moveUp; 
    public float health;
    // Start is called before the first frame update
    AnimatorClipInfo[]tfu;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Output the name of the starting clip
        
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(1));
        if(Input.GetKeyDown("w") && isGrounded() )
        {
            animator.SetTrigger("Jump");
            //print("jump");
            rb.AddForce(Vector2.up * moveUp, ForceMode2D.Impulse);
        }
        //animator.Play();
        float input = Input.GetAxis("Horizontal");
        if(rb.velocity.magnitude < maxSpeed){
            rb.AddForce(Vector2.right * moveSpeed * input);
        }
        
        if(Input.GetKeyDown("e")){
            animator.SetTrigger("punch1");
        }

        if(Input.GetKey("a")|| Input.GetKey("d"))
        {
            animator.SetBool("isWalkin", true);
        }
        else{
            animator.SetBool("isWalkin", false);

        }

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
