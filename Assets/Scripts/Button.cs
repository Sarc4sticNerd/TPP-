using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int x1, y1;
    public GameObject obj;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            anim.SetBool("button",true);
        }
        if (collision.gameObject.CompareTag("Ghost"))
        {
            anim.SetBool("button", true);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("button", true);
        }
        obj.transform.position = new Vector2(10000,10000);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            anim.SetBool("button", false);
        }
        if (collision.gameObject.CompareTag("Ghost"))
        {
            anim.SetBool("button", false);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("button", false);
        }
        obj.transform.position = new Vector2(x1, y1);
    }
}
