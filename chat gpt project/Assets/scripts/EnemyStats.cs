using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    void Start()
    {
        float maxSize =
    Mathf.Min(5f,
        3f + GameManager.Instance.GetSurvivalTime() / 60f);

        float size = Random.Range(0.5f, maxSize);


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

        float difficulty =
    GameManager.Instance.GetDifficultyMultiplier();

        health.maxHealth =
            Mathf.Round(Mathf.Pow(size, 2f) * 5f * difficulty);

        enemyDamage.damage =
            Mathf.Round(size * 2f * difficulty);

        follow.moveSpeed =
            Mathf.Lerp(
                5f,
                1.5f,
                (size - 0.5f) / (3f - 0.5f)
            ) * Mathf.Sqrt(difficulty);


    }
}