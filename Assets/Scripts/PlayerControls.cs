using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D ninja;
    public Transform groundCheck;
    public Transform startPosition;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        ninja = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set the running speed
        ninja.velocity = new Vector2(1, ninja.velocity.y);

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        //Get touch input
        //if(Input.touchCount > 0)
        if (Input.GetMouseButtonDown(0) && onGround)
        {
            //On a touch add upwards velocity while maintaining forward velocity
            ninja.velocity = new Vector2(ninja.velocity.x, 5);
        }
    }
}
