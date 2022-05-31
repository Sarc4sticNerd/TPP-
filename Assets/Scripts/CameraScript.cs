using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private bool changeV;
    private bool changeV2;
    private float timer = 1;
    private bool onGhost = false;
    public GameObject ghost;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.E) && onGhost == false && timer > 2)
        {
            onGhost = true;
            
            timer = 1;
        }
        if (Input.GetKeyUp(KeyCode.E) && onGhost == true && timer > 2)
        {
            onGhost = false;
            
            timer = 1;
        }
        if(onGhost == true)
        {

            transform.position = new Vector3(ghost.transform.position.x,ghost.transform.position.y,-10);
        }
        else if(onGhost == false)
        {

            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        }
    }
}
