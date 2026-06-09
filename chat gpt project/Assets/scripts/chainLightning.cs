using UnityEngine;

public class ChainLightning : MonoBehaviour
{
    public float damage = 15f;
    public float range = 10f;

    void Start()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            range);

        int chains = 5;

        foreach (Collider hit in hits)
        {
            EnemyHealth enemy =
                hit.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);

                chains--;

                if (chains <= 0)
                    break;
            }
        }

        Destroy(gameObject, 0.1f);
    }
}
