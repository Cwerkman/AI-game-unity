using UnityEngine;

public class FreezeSpell : MonoBehaviour
{
    public float radius = 8f;
    public float duration = 3f;

    void Start()
    {
        Collider[] hits =
            Physics.OverlapSphere(
                transform.position,
                radius);

        foreach (Collider hit in hits)
        {
            EnemyFollow enemy =
                hit.GetComponent<EnemyFollow>();

            if (enemy != null)
            {
                enemy.Freeze(0.5f, duration);
            }
        }

        Destroy(gameObject);
    }
}