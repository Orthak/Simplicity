using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerStats))]
public class PlayerGUI : MonoBehaviour
{
    #region Private Properties
    private GameObject healthBar;
    private GameObject healthBarEmpty;
    private GameObject experienceBar;
    private GameObject experienceBarEmpty;
    private TextMesh currentLevelText;
    private TextMesh currentAreaText;
    private TextMesh currentScoreText;
    private TextMesh currentLivesText;
    private float guiYScale;
    private float guiZScale;
    private PlayerStats player;
    private GameController controller;
    #endregion

    #region Unity Methods
    private void Start()
    {
        player = this.gameObject.GetComponent<PlayerStats>();
        controller = GameObject.Find("GameController").GetComponent<GameController>();

        guiYScale = .15f;
        guiZScale = 1f;

        InitGUIElements();
    }

    private void Update()
    {
        SetScoreGUI(player.score);
    }
    #endregion

    private void InitGUIElements()
    {
        healthBar = GameObject.Find("HealthBar").gameObject;
        healthBarEmpty = GameObject.Find("HealthBarEmpty").gameObject;
        experienceBar = GameObject.Find("ExperienceBar").gameObject;
        experienceBarEmpty = GameObject.Find("ExperienceBarEmpty").gameObject;
        currentLevelText = GameObject.Find("PlayerLevel").GetComponent<TextMesh>();
        currentAreaText = GameObject.Find("Area").GetComponent<TextMesh>();
        currentScoreText = GameObject.Find("Score").GetComponent<TextMesh>();
        currentLivesText = GameObject.Find("PlayerLives").GetComponent<TextMesh>();

        healthBar.transform.localScale
            = new Vector3(player.maxHealth / 100f, guiYScale, guiZScale);
        healthBarEmpty.transform.localScale
            = new Vector3(player.maxHealth / 100, .03f, .9f);
        experienceBar.transform.localScale
            = new Vector3(player.currentExperience / 100, guiYScale, guiZScale);
        experienceBarEmpty.transform.localScale
            = new Vector3(player.maxExperience / 100, .03f, .9f);
    }

    #region Public Methods
    public void SetHealthGUI()
    {
        healthBar.transform.localScale
            = new Vector3(player.currentHealth / 100, guiYScale, guiZScale);
        healthBarEmpty.transform.localScale
            = new Vector3(player.maxHealth / 100, .03f, .9f);
    }

    public void SetExperienceGUI()
    {
        currentLevelText.text = player.currentLevel.ToString();

        experienceBar.transform.localScale
            = new Vector3(
                Mathf.Clamp(player.currentExperience / 100, 0f, player.maxExperience / 100), 
                guiYScale, guiZScale);
        experienceBarEmpty.transform.localScale
            = new Vector3(player.maxExperience / 100, .03f, .9f);
    }

    public void SetAreaGUI(int currentArea)
    {
        currentAreaText.text = currentArea.ToString();
    }

    public void SetScoreGUI(int currentScore)
    {
        currentScoreText.text = currentScore.ToString();
    }

    public void SetLivesGUI(int currentLives)
    {
        currentLivesText.text = currentLives.ToString();
    }
    #endregion
}