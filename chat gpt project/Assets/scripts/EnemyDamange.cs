using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10f;
    public float attackCooldown = 1f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (timer >= attackCooldown)
            {
                collision.gameObject
                    .GetComponent<PlayerHealth>()
                    .TakeDamage(damage);

                timer = 0f;
            }
        }
    }
}