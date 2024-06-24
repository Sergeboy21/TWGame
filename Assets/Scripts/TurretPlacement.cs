using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    public GameObject turretPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button is clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "placeable")
                {
                    PlaceTurret(hit.point);
                }
            }
        }
    }

    void PlaceTurret(Vector3 position)
    {
        Instantiate(turretPrefab, position, Quaternion.identity);
    }
}

