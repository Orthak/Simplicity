using UnityEngine;
using System.Collections;
using System;

public class HandlePlayerDeath : MonoBehaviour
{
    #region Private Properties
    private PlayerStats player;
    private PlayerGUI playerGUI;
    private Camera gameOverCamera;
    private bool menuShown = false;
    #endregion

    #region Unity Methods
    private void Start()
    {
        player = this.gameObject.GetComponent<PlayerStats>();
        playerGUI = this.gameObject.GetComponent<PlayerGUI>();
        gameOverCamera = GameObject.Find("GameOverMenuCamera").camera;
    }

    private void LateUpdate()
    {
        if (player.isDead)
        {
            if (player.lives > 0)
                Invoke("RespawnPlayer", 5f);

            if (player.lives <= 0 && menuShown == false)
                ToggleGameOverMenu();
        }
    }
    #endregion

    private void RespawnPlayer()
    {
        player.lives--;
        player.isDead = false;
        player.ResetCurrentHealth();
        playerGUI.SetLivesGUI(player.lives);

        player.renderer.enabled = true;
        player.TogglePlayerControl(true);

        // This prevents the method from being accidentally called WAY more than
        // just the once it needs. 
        CancelInvoke("RespawnPlayer");
    }

    private void ToggleGameOverMenu()
    {
        menuShown = true;
        gameOverCamera.enabled = true;
    }
}
