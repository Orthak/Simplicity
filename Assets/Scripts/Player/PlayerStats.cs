using UnityEngine;
using System.Collections;
using Assets.Scripts;

[RequireComponent(typeof(PlayerGUI))]
public class PlayerStats : MonoBehaviour
{
    #region Public Properties
    public int maxLevel { get; set; }
    public int currentLevel { get; set; }
    public int lives { get; set; }
    public int score { get; set; }
    public bool isDead { get; set; }
    public float power { get; set; }
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public float maxExperience { get; set; }
    public float currentExperience { get; set; }
    #endregion

    #region Private Properties
    private PlayerGUI guiElements;
    private EnemyStats enemy;
    private PlayerAudio playerDeathSound;
    private PlayerAudio playerLevelUpSound;
    #endregion

    #region Unity Methods
    private void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<EnemyStats>()
                ?? (enemy = new EnemyStats());
        guiElements = this.gameObject.GetComponent<PlayerGUI>();
        playerDeathSound = GameObject.Find("PlayerDeathSound").GetComponent<PlayerAudio>();
        playerLevelUpSound = GameObject.Find("PlayerLevelUpSound").GetComponent<PlayerAudio>();

        SetStartingStats();
    }

    private void Update()
    {
        // We need to have these things happen each frame, but not have the 
        // Update() method get over bloated with logic.
        UpdateHealth();
        UpdateExperience();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            UpdateHealth(current: -enemy.power);
            Destroy(collision.gameObject);
        }
    }
    #endregion

    private void SetStartingStats()
    {
        maxLevel = 15;
        currentLevel = 1;
        lives = 3;
        score = 0;
        isDead = false;
        power = 5f;
        maxHealth = 100f;
        currentHealth = maxHealth;
        maxExperience = 100f;
        currentExperience = 0f;
    }

    private void UpdateHealth(float max = 1f, float current = 0f, bool isLevelUp = false)
    {
        maxHealth *= max;

        // We only want to heal th player if they level up, otherwise adjust the
        // health accordingly. 
        if (isLevelUp)
            currentHealth = maxHealth;
        else
            currentHealth += current;

        guiElements.SetHealthGUI();
        if (currentHealth <= 0 && isDead == false)
        {
            this.gameObject.GetComponent<GibOnDeath>().ExplodeIntoGibs();
            isDead = true;
            currentHealth = 0;
            TogglePlayerControl(false);
            playerDeathSound.PlayAudioClip();
            this.gameObject.renderer.enabled = false;
        }
    }

    private void UpdateExperience()
    {
        if(currentLevel < maxLevel)
            if (currentExperience >= maxExperience)
            {
                playerLevelUpSound.PlayAudioClip();

                currentLevel++;

                currentExperience = 0;
                maxExperience *= 1.2f;

                // When the player levels up, we need to increase their health, 
                // and set the current heal to the new max. 
                UpdateHealth(1.2f, 0f, true);

                power *= 1.3f;
            }

        guiElements.SetExperienceGUI();
    }

    /// <summary>
    /// If the player dies, then we need to set their health back to the current
    /// maximum when they respawn. This keeps them from dieing perpetually until 
    /// they run out of lives, almost instantly.
    /// </summary>
    public void ResetCurrentHealth()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Either allow or disallow the player to move and shoot.
    /// </summary>
    /// <param name="canControl">
    ///     Whether the player character can be controlled.
    /// </param>
    public void TogglePlayerControl(bool canControl)
    {
        if (canControl.Equals(true))
        {
            gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            gameObject.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            gameObject.GetComponent<PlayerKeyboardMovement>().enabled = true;
            gameObject.GetComponent<PlayerMouseShoot>().enabled = true;
        }
        else if (canControl.Equals(false))
        {
            gameObject.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            gameObject.GetComponent<PlayerKeyboardMovement>().enabled = false;
            gameObject.GetComponent<PlayerMouseShoot>().enabled = false;
        }
    }
}