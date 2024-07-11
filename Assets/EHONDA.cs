using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHONDA : MonoBehaviour
{
    Animator animator;
    public float moveSpeed;
    public int health;
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            animator.SetTrigger("Jump");
            //print("jump");
            rb.AddForce(Vector2.up * moveUp, ForceMode2D.Impulse);
        }
        //animator.Play();
        float input = Input.GetAxis("Horizontal2");
        // print(input);
        if (rb.velocity.magnitude < maxSpeed) {
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

        if (Physics2D.OverlapCircle(center, radius, 1<<6)) {
            print("isgrounded");
        } else {
            print("not");
        }

        return Physics2D.OverlapCircle(center, radius, 1<<6);

    }

    public void GetHit()
    {
        animator.SetTrigger("Hit2");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Punchbrox"))
        {
            GetHit();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered collision with " + collision.gameObject.name);
        if (collision.gameObject.name == "Vega")
        {
            Debug.Log("collision with Vega");
        }
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            Debug.Log("collision with tag Vega");
        }
    }
    void OnCollisionStay(Collision collision){
        Debug.Log("Colliding with " + collision.gameObject.name);    
    }
    void OnCollisionExit(Collision collision){
        Debug.Log("Exited Collision with " + collision.gameObject.name);
    }
}








    















    

