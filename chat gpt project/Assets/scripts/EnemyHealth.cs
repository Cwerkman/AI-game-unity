using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    private float currentHealth;
    

    void Start()
    {
        InitializeHealth();

        currentHealth = maxHealth;

    }

    public void InitializeHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        float size = transform.localScale.x;

        int scoreValue = Mathf.RoundToInt(size * 10f);

        GameManager.Instance.AddScore(scoreValue);

        Destroy(gameObject);
    }
}