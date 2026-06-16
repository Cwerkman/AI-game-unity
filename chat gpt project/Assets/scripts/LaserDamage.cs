using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    public float damagePerSecond = 1f;

    private void OnTriggerStay(Collider other)
    {
        EnemyHealth enemy =
            other.GetComponentInParent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(
                damagePerSecond * Time.deltaTime
            );
        }
    }
}