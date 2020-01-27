using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public
    public Player player;
    public Text scoreDisplay;
    public GameObject startbutton;


    //private
    private float currentScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentScore = Mathf.Round(player.getScore());
        scoreDisplay.text = currentScore.ToString();

        if (!player.gameStarted)
        {
            startbutton.SetActive(true);
        }
    }


    public void startGame()
    {
        player.gameStarted = true;
        startbutton.SetActive(false);
    }
}
