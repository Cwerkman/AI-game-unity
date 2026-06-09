using UnityEngine;

public class ExplosionSpell : MonoBehaviour
{
    public float radius = 5f;
    public float damage = 25f;

    void Start()
    {
        Collider[] hits =
            Physics.OverlapSphere(
                transform.position,
                radius);

        foreach (Collider hit in hits)
        {
            EnemyHealth enemy =
                hit.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Destroy(gameObject, 0.1f);
    }
}