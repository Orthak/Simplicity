using UnityEngine;
using System.Collections;

public class EnemyHealthText : MonoBehaviour
{
    public GUIText healthText;

    private EnemyStats enemy;

    private void Start()
    {
        enemy = gameObject.GetComponentInParent<EnemyStats>();

        healthText.pixelOffset = new Vector2(0, 30);
    }

    private void Update()
    {
        healthText.text = enemy.currentHealth.ToString("0");
    } 
}
