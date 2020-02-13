using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "Custom/Theme", order = 1)]
public class SO_Theme : ScriptableObject
{
    //--- Public Variables ---//
    [Header("Shapes")]
    public Sprite[] m_shapeIcons;
    public Color m_shapeColour;

    [Header("Background")]
    public Sprite m_wheelIcon;
    public Color m_wheelColor;
    public Color m_backgroundColour;

    [Header("Font")]
    public Font m_fontStyle;
    public Color m_fontScoreColour;
    public Color m_fontHighScoreColour;

    [Header("Particles")]
    public Sprite m_successParticle;
    public Sprite m_failParticle;

    [Header("Sounds")]
    public AudioClip m_soundHit;
    public AudioClip m_soundMiss;
    public AudioClip m_soundGameOver;
}
