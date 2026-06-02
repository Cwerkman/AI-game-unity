using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public GameObject spellPrefab;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastSpell();
        }
    }

    void CastSpell()
    {
        
        Instantiate(
            spellPrefab,
            firePoint.position,
            firePoint.rotation
        );
    }
}
