using UnityEngine;
using UnityEngine.UI;

public class Theme_Manager : MonoBehaviour
{
    //--- Public Variables ---//
    public SO_Theme m_selectedTheme;



    //--- Unity Methods ---//
    private void Awake()
    {
        // Setup the shapes
        Player player = GameObject.FindObjectOfType<Player>();
        player.sprites = m_selectedTheme.m_shapeIcons;
        player.GetComponent<SpriteRenderer>().color = m_selectedTheme.m_shapeColour;

        // Setup the background
        GameObject backgroundObj = GameObject.Find("BG");
        SpriteRenderer backgroundRend = backgroundObj.GetComponent<SpriteRenderer>();
        backgroundRend.sprite = m_selectedTheme.m_wheelIcon;
        backgroundRend.color = m_selectedTheme.m_wheelColor;
        Camera.main.backgroundColor = m_selectedTheme.m_backgroundColour;

        // Setup the font
        Text[] textObjs = GameObject.FindObjectsOfType<Text>();
        foreach (Text txt in textObjs)
            txt.font = m_selectedTheme.m_fontStyle;
        GameObject.Find("Score UI").GetComponent<Text>().color = m_selectedTheme.m_fontScoreColour;
        GameObject.Find("High Score UI").GetComponent<Text>().color = m_selectedTheme.m_fontHighScoreColour;

        // TODO: Setup the particles
        // ...

        // TODO: Setup the sounds
        // ...
    }
}
