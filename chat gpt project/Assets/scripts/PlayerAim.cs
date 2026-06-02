using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        AimAtMouse();
    }

    void AimAtMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);

            Vector3 lookDirection = point - transform.position;
            lookDirection.y = 0;

            if (lookDirection.magnitude > 0.1f)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }
}