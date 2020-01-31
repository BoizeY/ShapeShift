using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public
    public Player player;
    public Text scoreDisplay;
    public Text highScoreDisplay;
    public GameObject startbutton;


    //private
    private UIManager uiManager;
    private float currentScore;
    private float highScore;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>();
        uiManager.HideUI();

        updateHighScoreText();
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
        // Update the highscore text
        updateHighScoreText();

        // Start the game
        player.gameStarted = true;
        startbutton.SetActive(false);

        // Show the UI for the player controls
        uiManager.ShowUI();
    }

    public void updateHighScore(float _finalScore)
    {
        // Check to see if the score has beaten the high score
        if (_finalScore > highScore)
        {
            // If it has, we should update the value stored in the playerprefs
            PlayerPrefs.SetFloat("highScore", _finalScore);

            // Update the highscore text
            updateHighScoreText();
        }
    }

    public void updateHighScoreText()
    {
        // Grab the saved high score from the player prefs and show it on the UI
        highScore = PlayerPrefs.GetFloat("highScore", 0);
        highScoreDisplay.text = highScore.ToString("F0");
    }
}
