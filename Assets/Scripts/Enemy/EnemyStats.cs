using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    #region Public Properties
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public float power { get; set; }
    #endregion

    #region Private Properties
    private PlayerStats player;
    private GameController controller;
    private float hitExperience;
    private float killedExperience;
    private EnemyAudio enemyHitSound;
    private EnemyAudio enemyDeathSound;
    private bool isDead;
    #endregion

    #region Unity Methods
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        enemyHitSound = GameObject.Find("EnemyHitSound").GetComponent<EnemyAudio>();
        enemyDeathSound = GameObject.Find("EnemyDeathSound").GetComponent<EnemyAudio>();

        isDead = false;
        maxHealth = 50f;
        currentHealth = maxHealth;
        power = 40f;
        hitExperience = 5f;
        killedExperience = 10f;
        if (controller.currentArea > 1)
            for (int i = 1; i < controller.currentArea; i++)
                EnemyLevelUp();
    }

    private void Update()
    {
        if (currentHealth <= 0 && isDead == false)
        {
            isDead = true;
            enemyDeathSound.PlayAudioClip();
            this.gameObject.GetComponent<GibOnDeath>().ExplodeIntoGibs();
            currentHealth = 0;
            player.currentExperience += killedExperience;
            player.score += (int)killedExperience;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= player.power;
            player.currentExperience += hitExperience;
            player.score += (int)hitExperience;
            enemyHitSound.PlayAudioClip();
            Destroy(collision.gameObject);
        }
    }
    #endregion

    public void EnemyLevelUp()
    {
        maxHealth *= 1.6f;
        currentHealth = maxHealth;
        power *= 1.8f;
        hitExperience *= 1.5f;
        killedExperience *= 1.7f;
    }
}