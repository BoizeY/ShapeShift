using UnityEngine;
using UnityEngine.UI;

public enum MobileControlType
{
    Basic,              // Just shapeshift and attempt hit buttons
    Split,              // Forward / reverse shapeshift buttons with attempt hit button
    Split_With_Icons,   // Forward / reverse but icons to indicate what the change will be
    Direct,             // Change the shape to exactly the one on the button

    None                // None, use keyboard or gestures instead
}

public class UIManager : MonoBehaviour
{
    //--- Public Variables ---//
    public MobileControlType m_currentControlType;
    public GameObject m_controlUICanvas;
    public GameObject[] m_controlTypeUIs;

    [Header("Icon UI Controls")]
    public Sprite[] m_shapeIcons;
    public Image m_prevIcon;
    public Image m_nextIcon;



    //--- Methods ---//
    public void HideUI()
    {
        // Hide all of the UI
        m_controlUICanvas.SetActive(false);
    }

    public void ShowUI()
    {
        // Enable the parent UI
        m_controlUICanvas.SetActive(true);

        // Turn on the currently active UI canvas
        EnableCurrentUIType();
    }

    public void EnableCurrentUIType()
    {
        // Toggle all of the UI types depending on if that UI is currently selected
        m_controlTypeUIs[(int)MobileControlType.Basic].SetActive(m_currentControlType == MobileControlType.Basic);
        m_controlTypeUIs[(int)MobileControlType.Split].SetActive(m_currentControlType == MobileControlType.Split);
        m_controlTypeUIs[(int)MobileControlType.Split_With_Icons].SetActive(m_currentControlType == MobileControlType.Split_With_Icons);
        m_controlTypeUIs[(int)MobileControlType.Direct].SetActive(m_currentControlType == MobileControlType.Direct);
    }

    public void UpdateSplitIcons(int _currentShape)
    {
        // If the UI isn't active, don't do anything
        if (m_currentControlType != MobileControlType.Split_With_Icons)
            return;

        // Determine the next and previous indices
        int prevIcon = _currentShape - 1;
        int nextIcon = _currentShape + 1;

        // Wrap the indices if need be
        prevIcon = (prevIcon < 0) ? 3 : prevIcon;
        nextIcon = (nextIcon > 3) ? 0 : nextIcon;

        // Update the sprites on the icons
        m_prevIcon.sprite = m_shapeIcons[prevIcon];
        m_nextIcon.sprite = m_shapeIcons[nextIcon];
    }
}
