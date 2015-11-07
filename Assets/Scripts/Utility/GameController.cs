using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This class is used to house all of the major controls for the game.
/// These are things that control the game as a whole, or are high level actions.
/// </summary>
public class GameController : MonoBehaviour
{
    #region Public Properties
    public EnemyStats enemy;
    public float preventSpawnRadius;
    public int enemiesToSpawn = 3;
    public int currentArea { get; private set; }
    public PlayerStats player;
    #endregion

    #region Private Properties
    private GameObject[] enemiesInScene;
    private PlayerGUI playerGUI;
    private Camera gameOverCamera;
    private bool changeArea = false;
    #endregion

    #region Unity Methods
    private void Start()
    {
        playerGUI = GameObject.Find("Player").GetComponent<PlayerGUI>();
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
        gameOverCamera = GameObject.Find("GameOverMenuCamera").camera;
        gameOverCamera.enabled = false;
        Screen.showCursor = false;
        currentArea = 1;
        SpawnEnemies();
    }

    private void LateUpdate()
    {
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemiesInScene.Length == 0)
        {
            SpawnEnemies();
            ChangeArea();
        }

        if (Input.GetKeyDown(KeyCode.Escape)
            && player.isDead == false)
            gameOverCamera.enabled = !gameOverCamera;

    }
    #endregion

    // Predicate used to determine if the number of enemies spawned per wave 
    // should increase by one.
    private Predicate<int> IsEven =
        n => n % 2 == 0;

    private void ChangeArea()
    {
        audio.Play();
        player.score += 100 * currentArea;
        currentArea++;
        playerGUI.SetAreaGUI(currentArea);
    }

    private void SpawnEnemies()
    {
        if (IsEven(currentArea))
            enemiesToSpawn++;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (!Physics.CheckSphere(enemy.transform.position, preventSpawnRadius))
                Instantiate(enemy, UnityEngine.Random.insideUnitCircle * 26, Quaternion.identity);
        }
    }
}
