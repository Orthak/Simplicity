using UnityEngine;
using System.Collections;

public enum SelectionType
{
    Play,
    Exit,
    Help,
    Menu
}

public class GUISelectionText : MonoBehaviour
{
    public SelectionType actionType;
    public Color startColor;
    public Color onHover;

    private TextMesh thisTextMesh;

    #region Unity Methods
    private void Start()
    {
        thisTextMesh = this.gameObject.GetComponent<TextMesh>();
    }

    private void OnMouseOver()
    {
        thisTextMesh.color = onHover;
    }

    private void OnMouseExit()
    {
        thisTextMesh.color = startColor;
    }

    private void OnMouseDown()
    {
        switch (actionType)
        {
            case SelectionType.Play:
                Application.LoadLevel("MainScene");
                break;
            case SelectionType.Exit:
                Application.Quit();
                break;
            case SelectionType.Help:
                Application.LoadLevel("HelpScene");
                break;
            case SelectionType.Menu:
                Application.LoadLevel("MainMenuScene");
                break;
            default:
                break;
        }
    }
    #endregion
}
