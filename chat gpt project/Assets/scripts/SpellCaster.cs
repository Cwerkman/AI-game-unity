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

    private GameObject activeLaser;

    void Update()
    {
        HandleSpellSelection();

        if (currentSpell == SpellType.Laser)
        {
            HandleLaser();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                CastSpell();
            }
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
            if (currentSpell == SpellType.Laser)
            {
                HandleLaser();
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CastSpell();
                }
            }

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

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(
                        explosionPrefab,
                        hit.point,
                        Quaternion.identity
                    );
                }

                break;
        }
    }
    void HandleLaser()
    {
        if (Input.GetMouseButton(0))
        {
            activeLaser = Instantiate(
                laserPrefab,
                firePoint.position,
                firePoint.rotation
            );
        }

        if (Input.GetMouseButton(0))
        {
            if (activeLaser != null)
            {
                activeLaser.transform.position = firePoint.position;
                activeLaser.transform.rotation = firePoint.rotation;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (activeLaser != null)
            {
                Destroy(activeLaser);
            }
        }
    }
}
