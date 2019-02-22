using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public bool loop;
    public double frameSeconds = .1;

    //File location for sprites
    public string location = "Running/";

    private SpriteRenderer spr;
    private Sprite[] sprites;
    private int frame = 0;
    private double deltaTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>(location);
    }

    // Update is called once per frame
    void Update()
    {
        //How much time has passed
        deltaTime += Time.deltaTime;
        
        //Loop through sprites
        while (deltaTime >= frameSeconds)
        {
            deltaTime -= frameSeconds;
            frame++;

            if (frame >= sprites.Length)
                frame = 0;
        }

        spr.sprite = sprites[frame];
    }
}
