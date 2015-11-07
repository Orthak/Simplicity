using UnityEngine;
using System.Collections;
using System;

public class GUISetHelpText : MonoBehaviour
{
    void Start()
    {
        this.guiText.text =
                "HOW TO PLAY"
            + Environment.NewLine
            + "Move with the arrow keys, or W,A,S,D."
            + Environment.NewLine
            + Environment.NewLine
            + "Gain experience from damaging and killing enemies to level up."
            + Environment.NewLine
            + "Leveling increases shot power and overall health."
            + Environment.NewLine
            + Environment.NewLine
            + "Kill all the enemies on the screen to advance through the waves."
            + Environment.NewLine
            + "Enemies level up with each wave completed."
            + Environment.NewLine
            + Environment.NewLine
            + "Reach the 25th wave to win!";
    }
}
