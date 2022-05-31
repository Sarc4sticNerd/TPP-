using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float inRadius;
    private float timer = 1;
    private bool controlG = false;
    private float hoz;
    public float pSpeed = 5;
    public float pJump = 5;
    private bool touchingGround;
    public GameObject ghost;
    private Collider2D coll;
    private Rigidbody2D rb;
    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.E) && controlG == false && timer > 2)
        {
            controlG = true;
            timer = 1;
            Debug.Log("true");
            rb.velocity = new Vector2(0, rb.velocity.y);
            ghost.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        if (Input.GetKeyUp(KeyCode.E) && controlG == true && timer > 2)
        {
            controlG = false;
            timer = 1;
            Debug.Log("false");
            
        }
        if (controlG == false)
        {
            hoz = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(hoz * pSpeed, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
            {
                rb.velocity = new Vector2(rb.velocity.y, pJump);
            }
        }
        
    }
    void FixedUpdate()
    {
        touchingGround = Physics2D.BoxCast(coll.bounds.center, transform.localScale, 0, Vector2.down, .1f, ground);
        inRadius = Vector2.Distance(transform.position, ghost.transform.position);
    }

}
