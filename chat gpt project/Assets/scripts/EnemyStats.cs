using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    void Start()
    {
        float size = Random.Range(0.5f, 3f);

        transform.localScale = Vector3.one * size;

        EnemyHealth health = GetComponent<EnemyHealth>();

        health.maxHealth = Mathf.Round(Mathf.Pow(size, 2.2f) * 6f);

        // IMPORTANT: reset AFTER setting HP
        health.InitializeHealth();

        EnemyDamage enemyDamage = GetComponent<EnemyDamage>();
        enemyDamage.damage = Mathf.Round(Mathf.Pow(size, 1.2f) * 2f);

        EnemyFollow follow = GetComponent<EnemyFollow>();

        follow.moveSpeed = Mathf.Lerp(5f, 1.5f,
            (size - 0.5f) / (3f - 0.5f));

        // darker / more intense color for big enemies
        Renderer r = GetComponentInChildren<Renderer>();
        if (r != null)
        {
            float t = (size - 0.5f) / (3f - 0.5f);
            r.material.color = Color.Lerp(Color.green, Color.red, t);
        }

        follow.moveSpeed = Mathf.Lerp(
            5f,    // speed when small
            1.5f,  // speed when large
            (size - 0.5f) / (3f - 0.5f)
        );

        
    }
}