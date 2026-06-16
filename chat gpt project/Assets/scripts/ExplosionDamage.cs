using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public float damage = 25f;

    void Start()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            GetComponent<SphereCollider>().radius
        );

        foreach (Collider hit in hits)
        {
            EnemyHealth enemy =
                hit.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Destroy(gameObject, 0.5f);
    }
}
