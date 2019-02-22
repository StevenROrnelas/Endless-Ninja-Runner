using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsAndAnimations : MonoBehaviour
{
    //Variables for Player Control
    public Rigidbody2D ninja;
    public Transform groundCheck;
    public Transform startPosition;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    //Variables for Animation
    public bool loop;
    public double frameSeconds = .1;

    //File location for sprites
    public string location = "Running/";

    private SpriteRenderer spr;
    private Sprite[] sprites;
    private int frame = 0;
    private double deltaTime = 0;
    private string spriteType = "Running";


    // Start is called before the first frame update
    void Start()
    {
        ninja = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>(location);
    }

    // Update is called once per frame
    void Update()
    {
        //Set the running speed
        ninja.velocity = new Vector2(1, ninja.velocity.y);

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        //Get touch input
        //if(Input.touchCount > 0)
        Debug.Log(onGround);
        if (Input.GetMouseButtonDown(0) && onGround)
        {
            //On a touch add upwards velocity while maintaining forward velocity
            ninja.velocity = new Vector2(ninja.velocity.x, 5);

            //get jumping sprites
            spriteType = "Jumping";
            getSprites("Jumping");
        }

        //How much time has passed
        deltaTime += Time.deltaTime;

        //Loop through sprites
        while (deltaTime >= frameSeconds)
        {
            deltaTime -= frameSeconds;
            frame++;

            if (frame >= sprites.Length)
            {
                //If we are not running we need to hold the last frame for smooth animation
                if (spriteType != "Running")
                {
                    //Different check conditions for each type
                    switch (spriteType)
                    {
                        case "Jumping":
                            if (!onGround)
                                frame = sprites.Length;
                            break;
                       
                    }
                    spriteType = "Running";
                    getSprites("Running");
                }
                frame = 0;
            }
        }

        spr.sprite = sprites[frame];
    }

    void getSprites(string type)
    {
        switch (type)
        {
            case "Jumping": 
               sprites = Resources.LoadAll<Sprite>("Jumping/");
                break;

            case "Running":
                sprites = Resources.LoadAll<Sprite>("Running/");
                break;
        }

        frame = 0;

    }
}
