using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 3f;
    private float speedMultiplier = 1f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position +=
    direction * moveSpeed * speedMultiplier * Time.deltaTime;

        direction.y = 0;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }


    }
    public void Freeze(float multiplier, float duration)
    {
        StartCoroutine(FreezeRoutine(multiplier, duration));
    }

    System.Collections.IEnumerator FreezeRoutine(
        float multiplier,
        float duration)
    {
        speedMultiplier = multiplier;

        yield return new WaitForSeconds(duration);

        speedMultiplier = 1f;
    }
}