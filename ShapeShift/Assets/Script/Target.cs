using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    //array of different sprites
    public Sprite[] sprites;
    public Transform parent;

    private SpriteRenderer sr;
    private int spriteCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        changeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeSprite()
    {
        //randomize to new shape
        spriteCounter = Random.Range(0, 3);
        sr.sprite = sprites[spriteCounter];
        parent.Rotate(0, 0, Random.Range(90, 180));
    }

    public int getCurrentShape()
    {
        return spriteCounter;
    }
}
