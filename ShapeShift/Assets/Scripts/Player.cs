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
    public bool gameStarted;

    private GameManager gameManager;
    private UIManager uiManager;
    private SpriteRenderer sr;
    private int spriteCounter;
    private float totalScore;
    private int acc; // 0 = miss, 1 = Good, 2, Great, 3 = Excellent

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        uiManager = GameObject.FindObjectOfType<UIManager>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        gameStarted = false;
        resetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            transform.RotateAround(pivotPoint.position, Vector3.forward, speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.A))
            {
                spriteCycling();
            }

            //check if on target
            if (Input.GetKeyDown(KeyCode.Space))
            {
                attemptHit();
            }
        }
    }

    public void attemptHit()
    {
        //get distance to the target
        float dist = Vector3.Distance(target.transform.position, transform.position);

        if (spriteCounter == target.getCurrentShape() && (dist <= 1.0f))
        {
            //good hit
            if (dist <= 1.0f && dist > 0.5f)
            {
                totalScore += 1;
                acc = 1;
            }
            //great hit
            else if (dist <= 0.5f && dist > 0.1f)
            {
                totalScore += 2;
                acc = 2;
            }
            //execellent hit
            else if (dist <= 0.1f)
            {
                totalScore += 3;
                acc = 3;
            }

            //change target to something else
            target.changeSprite();

            //reverse the direction
            speed *= -1;

            // incease the speed of the game
            if (speed > 0)
            {
                speed += 1;
            }
            else
            {
                speed -= 1;
            }
        }
        //player miss, reset game
        else
        {
            target.changeSprite();
            resetGame();
            gameStarted = false;
        }
    }

    public void spriteCycling()
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

        // Update the UI if using the split UI with icons
        uiManager.UpdateSplitIcons(spriteCounter);
    }

    public void reverseSpriteCycling()
    {
        // Lower the sprite number
        spriteCounter--;

        // Wrap if need be
        spriteCounter = (spriteCounter < 0) ? 3 : spriteCounter;

        // Update the icon on screen
        sr.sprite = sprites[spriteCounter];

        // Update the UI if using the split UI with icons
        uiManager.UpdateSplitIcons(spriteCounter);
    }

    public void setSpriteDirectly(int _newIndex)
    {
        // Set the sprite counter
        spriteCounter = _newIndex;

        // Update the visuals
        sr.sprite = sprites[spriteCounter];
    }

    void resetGame()
    {
        spriteCounter = 0;

        spriteCycling();

        uiManager.HideUI();
        gameManager.updateHighScore(totalScore);

        // Update the UI if using the split UI with icons
        uiManager.UpdateSplitIcons(spriteCounter);

        totalScore = 0;
        speed = 50;
        acc = 0;
    }

    //score getter && setter
    public float getScore()
    {
        return totalScore;
    }
    public void setScore()
    {
        totalScore = 0.0f;
    }

    //get accurcy
    public int getAcc()
    {
        return acc;
    }
}
