using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    
    private float timer = 1;
    private bool controlG = false;
    private float hoz;
    private float vert;
    public float gSpeed = 5;
    public GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetKeyUp(KeyCode.E) && controlG == false && timer > 2)
        {
            controlG = true;
            timer = 1;
            Debug.Log("true GG");
            sprite.color = Color.white;
        }
        if (Input.GetKeyUp(KeyCode.E) && controlG == true && timer > 2)
        {
            controlG = false;
            timer = 1;
            Debug.Log("false GG");
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
            sprite.color = Color.clear;
        }
        if (controlG == true)
        {
            hoz = Input.GetAxisRaw("Horizontal");
            vert = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(hoz * gSpeed, vert * gSpeed);
        }
        
    }
}
