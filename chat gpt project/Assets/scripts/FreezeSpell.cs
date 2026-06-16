using UnityEngine;

public class FreezeSpell : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] hits =
            Physics.OverlapSphere(
                transform.position,
                5f);

        foreach (Collider hit in hits)
        {
            EnemyFollow enemy =
                hit.GetComponent<EnemyFollow>();

            if (enemy != null)
            {
                enemy.Freeze(0.2f, 3f);
            }
        }

        Destroy(gameObject);
    }
}