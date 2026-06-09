using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public enum SpellType
    {
        Fireball,
        Lightning,
        Freeze,
        Laser,
        Explosion
    }
    public SpellType currentSpell = SpellType.Fireball;

    public GameObject fireballPrefab;
    public GameObject lightningPrefab;
    public GameObject freezePrefab;
    public GameObject laserPrefab;
    public GameObject explosionPrefab;

    public Transform firePoint;

    void Update()
    {
        HandleSpellSelection();

        if (Input.GetMouseButtonDown(0))
        {
            CastSpell();
        }
    }

    void HandleSpellSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentSpell = SpellType.Fireball;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentSpell = SpellType.Lightning;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            currentSpell = SpellType.Freeze;

        if (Input.GetKeyDown(KeyCode.Alpha4))
            currentSpell = SpellType.Laser;

        if (Input.GetKeyDown(KeyCode.Alpha5))
            currentSpell = SpellType.Explosion;
    }

    void CastSpell()
    {
        switch (currentSpell)
        {
            case SpellType.Fireball:
                Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
                break;

            case SpellType.Lightning:
                Instantiate(lightningPrefab, firePoint.position, firePoint.rotation);
                break;

            case SpellType.Freeze:
                Instantiate(freezePrefab, firePoint.position, firePoint.rotation);
                break;

            case SpellType.Laser:
                Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
                break;

            case SpellType.Explosion:
                Instantiate(explosionPrefab, firePoint.position, firePoint.rotation);
                break;
        }
    }
}
