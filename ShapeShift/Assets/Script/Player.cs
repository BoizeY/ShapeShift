using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //pivot that it rotates around
    public Transform pivotPoint;
    //array of different sprites
    public Sprite[] sprites;
    //taget object
    public Target target;
    //rotation speed
    public int speed;

    private SpriteRenderer sr;
    private int spriteCounter;
    private float totalScore;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        spriteCycling();
        spriteCounter = 0;
        totalScore = 0;
        speed = 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivotPoint.position, Vector3.forward, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteCycling();
        }

        //get distance to the target
        float dist = Vector3.Distance(target.transform.position, transform.position);
        //Debug.Log("Distance to other: " + dist);

        //check if on target
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(spriteCounter == target.getCurrentShape() && (dist <= 2.0))
            {
                totalScore += dist;
                Debug.Log("Correct Shape!" +" score = " + dist);
                Debug.Log("Total score = " + dist);
                target.changeSprite();
                speed *= -1;
            }
            else
            {
                target.changeSprite();
                Debug.Log("Miss =(");
            }
        }

    }


    void spriteCycling()
    {
        if (spriteCounter == 3)
        {
            spriteCounter = 0;
            sr.sprite = sprites[spriteCounter];
        }
        else
        {
            spriteCounter++;
            sr.sprite = sprites[spriteCounter];
        }
    }

}
