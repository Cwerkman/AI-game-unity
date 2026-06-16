using UnityEngine;

public class LaserSpell : MonoBehaviour
{
    public float damage = 50f;
    public float range = 100f;

    void Start()
    {
        RaycastHit[] hits =
            Physics.RaycastAll(
                transform.position,
                transform.forward,
                range);
        transform.position += transform.forward * 30f;

        foreach (RaycastHit hit in hits)
        {
            EnemyHealth enemy =
                hit.collider.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Destroy(gameObject, 0.1f);
    }
}